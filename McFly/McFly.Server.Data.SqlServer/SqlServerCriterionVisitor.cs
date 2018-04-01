using System.Text;

namespace McFly.Server.Data.SqlServer
{
    internal class SqlServerCriterionVisitor : ICriterionVisitor
    {
        private readonly StringBuilder _builder = new StringBuilder();

        public object Visit(ICriterion criterion)
        {
            return _builder.ToString();
        }

        public void Visit(AndCriterion andCriterion)
        {
            _builder.Append(" (");

            var isFirst = true;
            foreach (var criterion in andCriterion.Criteria)
            {
                criterion.Accept(this);
                if (isFirst)
                {
                    isFirst = false;
                    continue;
                }
                _builder.Append(" AND ");
            }
            _builder.Append(" )");
        }

        public void Visit(OrCriterion orCriterion)
        {
            _builder.Append(" (");

            var isFirst = true;
            foreach (var criterion in orCriterion.Criteria)
            {
                criterion.Accept(this);
                if (isFirst)
                {
                    isFirst = false;
                    continue;
                }
                _builder.Append(" OR ");
            }
            _builder.Append(" )");
        }

        public void Visit(NotCriterion notCriterion)
        {
            _builder.Append(" NOT (");
            notCriterion.Criterion.Accept(this);
            _builder.AppendLine(")");
        }

        public void Visit(RegisterEqualsCriterion registerEquals)
        {
            _builder.Append($" [rax] = {registerEquals} ");
        }

        public override string ToString()
        {
            return _builder.ToString();
        }
    }
}