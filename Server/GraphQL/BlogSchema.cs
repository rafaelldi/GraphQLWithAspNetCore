using GraphQL.Types;

namespace Server.GraphQL
{
    public class BlogSchema : Schema
    {
        public BlogSchema(ArticleService articleService)
        {
            Query = new BlogQuery(articleService);
            Mutation = new BlogMutation(articleService);
        }
    }
}