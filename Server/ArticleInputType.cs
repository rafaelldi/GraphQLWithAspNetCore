using GraphQL.Types;

namespace Server
{
    public class ArticleInputType : InputObjectGraphType<Article>
    {
        public ArticleInputType()
        {
            Field(x => x.Title);
            Field(x => x.Author);
            Field(x => x.Content);
        }
    }
}