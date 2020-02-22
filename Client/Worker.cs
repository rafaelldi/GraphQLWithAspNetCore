using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using GraphQL.Client.Http;
using Microsoft.Extensions.Hosting;

namespace Client
{
    public class Worker : BackgroundService
    {
        private readonly IHttpClientFactory _factory;
        private const string CreateCommand = "create";
        private const string GetListCommand = "get-list";

        public Worker(IHttpClientFactory factory)
        {
            _factory = factory;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                Console.WriteLine("Type a command.");
                var command = Console.ReadLine();
                if (command != CreateCommand && command != GetListCommand)
                {
                    Console.WriteLine("Wrong command. Try again.");
                    continue;
                }
                
                using var client = _factory.CreateClient("localhost");
                using var graphqlClient = client.AsGraphQLClient("http://localhost:5000/graphql");

                if (command is GetListCommand)
                {
                    var getRequest = new GraphQLHttpRequest
                    {
                        Query = @"query
{
    list {
        title
        author  
        content
    }
}"
                    };
                    var response = await graphqlClient.SendQueryAsync<GraphQLRespone>(getRequest, stoppingToken);
                    Console.WriteLine($"We have {response.Data.List.Count} articles");
                    foreach (var article in response.Data.List)
                    {
                        Console.WriteLine($"Article '{article.Title}' by {article.Author}");
                    }
                } else if (command is CreateCommand)
                {
                    Console.WriteLine("Type a title");
                    var title = Console.ReadLine();
                    Console.WriteLine("Type an author");
                    var author = Console.ReadLine();
                    Console.WriteLine("Type a content");
                    var content = Console.ReadLine();
                    
                    var article = new Article {Title = title, Author = author, Content = content};
                    var createRequest = new GraphQLHttpRequest()
                    {
                        Query = @"mutation($article: ArticleInputType!) 
{
    create(article: $article) {
        title  
        author  
        content
    }
}",
                        Variables = new {
                            article
                        }
                    };
                    await graphqlClient.SendMutationAsync<Article>(createRequest, stoppingToken);
                }
            }
        }
    }
}
