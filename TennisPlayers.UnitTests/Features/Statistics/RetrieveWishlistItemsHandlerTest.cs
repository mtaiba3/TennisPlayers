using Wishlist.Application.Features.RetrieveWishlistItems;
using Wishlist.UnitTests.Implementations;

namespace Wishlist.UnitTests.Features;

public class RetrieveWishlistItemsHandlerTest
{
    [Fact]
    public async Task ShouldRetrieveWishlistItems()
    {
        var query = new RetrieveWishlistItemsQuery(Guid.NewGuid(), Guid.NewGuid());
        var handler =
            new RetrieveWishlistItemsQueryHandler(new StubRetrieveItemsDataAccess(new List<WishlistItemDto>
                { new(234, 12, 1, 1) }));
        var result = await handler.Handle(query, CancellationToken.None);
        Assert.Equal(1, result.Count);
        Assert.Collection(result.Items, item => Assert.Equal(item, new WishlistItemDto(234, 12, 1, 1)));
    }
}