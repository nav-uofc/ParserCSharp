/*** BNFC-Generated Visitor Design Pattern Skeleton. ***/
/* This implements the common visitor design pattern. To make sure that
   compile errors occur when code in the Visitor don't match the abstract
   syntaxt, the "abstract visit skeleton" is used.
   
   Replace the R and A parameters with the desired return
   and context types.*/

namespace gplex.VisitSkeleton
{
  #region Classes
  public class ExprVisitor<R,A> : AbstractExprVisitor<R,A>
  {
    public override R Visit(gplex.Absyn.Expr1 expr1_, A arg)
    {
      /* Code For Expr1 Goes Here */
      expr1_.Term_1.Accept(new TermVisitor<R,A>(), arg);
      expr1_.Term_2.Accept(new TermVisitor<R,A>(), arg);
      return default(R);
    }
 
    public override R Visit(gplex.Absyn.ExprTerm exprterm_, A arg)
    {
      /* Code For ExprTerm Goes Here */
      exprterm_.Term_.Accept(new TermVisitor<R,A>(), arg);
      return default(R);
    }
  }
 
  public class TermVisitor<R,A> : AbstractTermVisitor<R,A>
  {
    public override R Visit(gplex.Absyn.TermIdent termident_, A arg)
    {
      /* Code For TermIdent Goes Here */
      // termident_.Ident_
      return default(R);
    }
 
    public override R Visit(gplex.Absyn.TermInteger terminteger_, A arg)
    {
      /* Code For TermInteger Goes Here */
      // terminteger_.Integer_
      return default(R);
    }
  }
  #endregion
  
  #region Token types

  #endregion
}
