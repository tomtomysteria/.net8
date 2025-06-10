namespace ProductApi.GraphQL.Extensions;

public class QueryTypeExtension : ObjectTypeExtension<Query>
{
  protected override void Configure(IObjectTypeDescriptor<Query> descriptor)
  {
    // Configuration pour GetProducts
    descriptor.Field("products")
        .ResolveWith<Query>(q => Query.GetProducts(default!)) // Appel de la méthode statique
        .UseFiltering()
        .UseSorting();

    // Configuration pour GetProductById
    descriptor.Field("product")
        .ResolveWith<Query>(q => Query.GetProductById(default, default!)) // Appel de la méthode statique
        .Argument("id", a => a.Type<NonNullType<IntType>>())
        .UseFiltering()
        .UseSorting();
  }
}
