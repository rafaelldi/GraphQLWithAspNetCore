using GraphQL.Types;

namespace Server
{
    public class BlogSchema : Schema
    {
        public BlogSchema(ArticleService service)
        {
            Query = new BlogQuery(service);
            Mutation = new BlogMutation(service);
        }
    }
}