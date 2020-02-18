using GraphQL;
using GraphQL.Types;

namespace Server
{
    public class BlogSchema : Schema
    {
        public BlogSchema(IDependencyResolver resolver) : base(resolver)
        {
            Query = resolver.Resolve<BlogQuery>();
        }
    }
}