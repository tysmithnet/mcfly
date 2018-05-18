using McFly.Server.Core;
using McFly.Server.Data.Search;
using McFly.Server.Search;
using Moq;

namespace McFly.Server.Test.Builders
{
    internal class SearchCriterionConverterBuilder
    {
        public Mock<ISearchCriterionConverter> Mock = new Mock<ISearchCriterionConverter>();

        public SearchCriterionConverterBuilder WithCanConvert(bool canConvert)
        {
            Mock.Setup(converter => converter.CanConvert(It.IsAny<SearchCriterionDto>())).Returns(canConvert);
            return this;
        }

        public SearchCriterionConverterBuilder WithConvert(ICriterion criterion)
        {
            Mock.Setup(converter => converter.Convert(It.IsAny<SearchCriterionDto>())).Returns(criterion);
            return this;
        }

        public ISearchCriterionConverter Build()
        {
            return Mock.Object;
        }
    }
}