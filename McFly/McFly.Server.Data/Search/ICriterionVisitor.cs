namespace McFly.Server.Data.Search
{
    public interface ICriterionVisitor
    {
        object Visit(ICriterion criterion);
        object Visit(AndCriterion andCriterion);
        object Visit(OrCriterion orCriterion);
        object Visit(NotCriterion notCriterion);
        object Visit(RegisterEqualsCriterion registerEqualsCriterion);
        object Visit(RegisterBetweenCriterion registerBetweenCriterion);
        object Visit(RegisterInCriterion registerInCriterion);
        object Visit(NoteCreatedAfterCriterion noteCreatedAfterCriterion);
        object Visit(NoteCreatedBeforeCriterion noteCreatedBeforeCriterion);
        object Visit(NoteCreatedBetweenCriterion noteCreatedBetweenCriterion);
    }
}