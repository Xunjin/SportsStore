using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Microsoft.AspNetCore.Routing;
using Moq;
using SportsStore.Components;
using SportsStore.Models;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace SportsStore.Tests
{
    /// <summary>
    /// Tests for the Component <see cref="NavigationMenuViewComponent"/>
    /// </summary>
    public class NavigationMenuViewComponentTests
    {
        /// <summary>
        /// Creates a <see cref="Mock.Mock"/> of <see cref="IProductRepository"/> that contains repeating categories and categories that are not in order. It Asserts that the duplicates are removed and that alphabetical ordering is imposed.
        /// </summary>
        [Fact]
        public void Can_Select_Categories()
        {
            // Arrange
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns((new Product[]{
                new Product {ProductID = 1, Name = "P1", Category = "Apples"},
                new Product {ProductID = 1, Name = "P2", Category = "Apples"},
                new Product {ProductID = 1, Name = "P3", Category = "Plums"},
                new Product {ProductID = 1, Name = "P4", Category = "Oranges"}
            }).AsQueryable<Product>());

            NavigationMenuViewComponent target =
                new NavigationMenuViewComponent(mock.Object);

            // Act = get the set of categories
            string[] results = ((IEnumerable<string>)(target.Invoke()
                as ViewViewComponentResult).ViewData.Model).ToArray();


            // Assert
            Assert.True(Enumerable.SequenceEqual(new string[] { "Apples", "Oranges", "Plums" }, results));
        }

        /// <summary>
        /// Provides the view component with routing data through the <see cref="ViewComponentContext"/> property providing access to view-specific context data throught its <seealso cref="ViewComponentContext.ViewContext"/> that turns into a routing information using <see cref="RouteData"/>
        /// </summary>
        [Fact]
        public void Indicates_Selected_Category()
        {
            // Arrange
            string categoryToSelect = "Apples";
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns((new Product[]
            {
                new Product {ProductID = 1, Name = "P1", Category="Apples"},
                new Product {ProductID = 4, Name = "P2", Category="Oranges"},
            }).AsQueryable<Product>());

            NavigationMenuViewComponent target = new NavigationMenuViewComponent(mock.Object);
            target.ViewComponentContext = new ViewComponentContext
            {
                ViewContext = new ViewContext
                {
                    RouteData = new RouteData()
                }
            };
            target.RouteData.Values["category"] = categoryToSelect;


            // Act
            string result = (string)(target.Invoke() as
                ViewViewComponentResult).ViewData["SelectedCategory"];


            // Assert
            Assert.Equal(categoryToSelect, result);
        }
    }
}
