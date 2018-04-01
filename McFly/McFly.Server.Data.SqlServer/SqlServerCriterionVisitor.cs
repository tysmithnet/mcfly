using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace McFly.Server.Data.SqlServer
{
    internal class SqlServerCriterionVisitor : ICriterionVisitor
    {
        

        public object Visit(ICriterion criterion)
        {
            return null;
        }

        public void Visit(AndCriterion andCriterion)
        {
            
        }

        public void Visit(OrCriterion orCriterion)
        {
         
        }

        public void Visit(NotCriterion notCriterion)
        {
          
        }

        public Func<FrameEntity, bool> Visit(RegisterEqualsCriterion registerEquals)
        {
            return entity => entity.Rax == 0;
        }
    }
}