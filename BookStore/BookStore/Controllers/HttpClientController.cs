using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using BookStore.Models;

namespace BookStore.Controllers
{
	public class HttpClientController
	{
		public class Product
		{
			public string bib_key { get; set; }
			public string info_url { get; set; }
			public string preview { get; set; }
			public string preview_url { get; set; }
			public string thumbnail_url { get; set; }
			public string jscmd { get; set; }
			public string url { get; set; }
			public string title { get; set; }
			public string subtitle { get; set; }
			public string authors { get; set; }
			public string identifiers { get; set; }
			public string classifications { get; set; }
			public string subjects { get; set; }
			public string subject_places { get; set; }
			public string subject_people { get; set; }
			public string subject_times { get; set; }
			public string publishers { get; set; }
			public string publish_places { get; set; }
			public string publish_date { get; set; }
			public string excerpts { get; set; }
			public string links { get; set; }
			public string cover { get; set; }
			public string ebooks { get; set; }
			public int number_of_pages { get; set; }
			public decimal weight { get; set; }
		}

		class Program
		{
			public string books_api = "https://openlibrary.org/api/books?bibkeys=ISBN:{0}&jscmd=data&format=json";
			private static string baseUrl = "https://openlibrary.org/";
			static HttpClient client = new HttpClient();

			private string getApiUrl(string url)
			{
				return baseUrl + url;
			}

			public void getBooks(string query, HttpMessageHandler handler)
			{
				string url = getApiUrl("search.json?q=");
			}

			static void ShowProduct(Product product)
			{
				List<string> bookIsbns = new List<string>();
				using (var db = new DatabaseContext())
				{
					foreach (var book in db.Books)
					{
						bookIsbns.Add(book.Bib_key);
					}

					
				}

					string message = "";
				switch (product.jscmd)
				{
					case "data":
						message = ($"Url: {product.url}\tTitle: {product.title}\tSubtitle:{product.subtitle}\tAuthors: {product.authors}\tIdentifiers: {product.identifiers}\tClassifications: {product.classifications}" +
							$"\tSubjects: {product.subjects}\tSubject_Places: {product.subject_places}\tSubject_People: {product.subject_people}\tSubject_Times: {product.subject_times}" +
							$"\tPublishers: {product.publishers}\tPublish_Places: {product.publish_places}\tPublish_Date: {product.publish_date}\tExcerpts: {product.excerpts}\tLinks: {product.links}\tCover: {product.cover}" +
							$"\teBooks: {product.ebooks}\tNumber_of_Pages: {product.number_of_pages}\tWeight: {product.weight}");
						break;
					case "details":
						message = ($"Bib_Key: {product.bib_key}\tInfo_Url: {product.info_url}\tPreview: {product.preview}\tPreview_Url: {product.preview_url}\tThumbnail_Url: {product.thumbnail_url}" +
							$"Url: {product.url}\tTitle: {product.title}\tSubtitle:{product.subtitle}\tAuthors: {product.authors}\tIdentifiers: {product.identifiers}\tClassifications: {product.classifications}" +
							$"\tSubjects: {product.subjects}\tSubject_Places: {product.subject_places}\tSubject_People: {product.subject_people}\tSubject_Times: {product.subject_times}" +
							$"\tPublishers: {product.publishers}\tPublish_Places: {product.publish_places}\tPublish_Date: {product.publish_date}\tExcerpts: {product.excerpts}\tLinks: {product.links}\tCover: {product.cover}" +
							$"\teBooks: {product.ebooks}\tNumber_of_Pages: {product.number_of_pages}\tWeight: {product.weight}");
						break;
					default:
						message = ($"Bib_Key: {product.bib_key}\tInfo_Url: {product.info_url}\tPreview: {product.preview}\tPreview_Url: {product.preview_url}\tThumbnail_Url: {product.thumbnail_url}");
						break;
				}
				Console.WriteLine(message);
			}

			// Sends a POST request to create a resource
			static async Task<Uri> CreateProductAsync(Product product)
			{
				HttpResponseMessage response = await client.PostAsJsonAsync(
					"api/products", product);
				response.EnsureSuccessStatusCode();

				// return URI of the created resource.
				return response.Headers.Location;
			}

			//Sends a GET request to retrieve a resource
			static async Task<Product> GetProductAsync(string path)
			{
				Product product = null;
				HttpResponseMessage response = await client.GetAsync(path);
				if (response.IsSuccessStatusCode)
				{
					product = await response.Content.ReadAsAsync<Product>();
				}
				return product;
			}

			//Sends a PUT request to update a resource
			static async Task<Product> UpdateProductAsync(Product product)
			{
				HttpResponseMessage response = await client.PutAsJsonAsync(
					$"api/products/{product.bib_key}", product);
				response.EnsureSuccessStatusCode();

				// Deserialize the updated product from the response body.
				product = await response.Content.ReadAsAsync<Product>();
				return product;
			}

			//Sends a DELETE request to delete a resource
			static async Task<HttpStatusCode> DeleteProductAsync(string bib_key)
			{
				HttpResponseMessage response = await client.DeleteAsync(
					$"api/products/{bib_key}");
				return response.StatusCode;
			}

			static void Main()
			{
				RunAsync().GetAwaiter().GetResult();
			}

			static async Task RunAsync()
			{
				// Update port # in the following line.
				client.BaseAddress = new Uri("http://localhost:64195/");
				client.DefaultRequestHeaders.Accept.Clear();
				client.DefaultRequestHeaders.Accept.Add(
					new MediaTypeWithQualityHeaderValue("application/json"));

				try
				{
					// Create a new product
					Product product = new Product
					{
						jscmd = "viewapi",
						bib_key = "ISBN:0201558025",
						preview_url = "https://openlibrary.org/books/0L1017798M/The_adventures_of_Tom_Sawyer",
						info_url = "https://openlibrary.org/books/0L1017798M/The_adventures_of_Tom_Sawyer",
						preview = "noview",
						thumbnail_url = "https://covers.openlibrary.org/b/id/295577-S.jpg"
					};

					var url = await CreateProductAsync(product);
					Console.WriteLine($"Created at {url}");

					// Get the product
					product = await GetProductAsync(url.PathAndQuery);
					ShowProduct(product);

					// Update the product
					Console.WriteLine("Updating price...");
					product.title = "Tom Sawyer";
					await UpdateProductAsync(product);

					// Get the updated product
					product = await GetProductAsync(url.PathAndQuery);
					ShowProduct(product);

					// Delete the product
					var statusCode = await DeleteProductAsync(product.bib_key);
					Console.WriteLine($"Deleted (HTTP Status = {(int)statusCode})");

				}
				catch (Exception e)
				{
					Console.WriteLine(e.Message);
				}

				Console.ReadLine();
			}
		}
	}
}
