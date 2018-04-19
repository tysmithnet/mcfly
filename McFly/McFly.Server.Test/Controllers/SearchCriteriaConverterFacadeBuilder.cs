using McFly.Server.Contract;
using McFly.Server.Data.Search;
using McFly.Server.Search;
using Moq;

namespace McFly.Server.Test.Controllers
{
    public class SearchCriteriaConverterFacadeBuilder
    {
        public Mock<ISearchCriterionConversionFacade> Mock = new Mock<ISearchCriterionConversionFacade>();

        public SearchCriteriaConverterFacadeBuilder WithConvert(ICriterion result)
        {
            Mock.Setup(facade => facade.Convert(It.IsAny<SearchCriterionDto>())).Returns(result);
            return this;
        }

        public ISearchCriterionConversionFacade Build()
        {
            return Mock.Object;
        }
    }
}