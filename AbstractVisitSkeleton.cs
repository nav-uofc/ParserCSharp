/*** BNFC-Generated Abstract Visitor Design Pattern Skeleton. ***/
/* This implements the common visitor design pattern.
   Replace the R and A parameters with the desired return
   and context types.*/

namespace gplex.VisitSkeleton
{
  #region Classes
  public abstract class AbstractExprVisitor<R,A> : gplex.Absyn.Expr.Visitor<R,A>
  {
    public abstract R Visit(gplex.Absyn.Expr1 expr1_, A arg);
 
    public abstract R Visit(gplex.Absyn.ExprTerm exprterm_, A arg);
  }
 
  public abstract class AbstractTermVisitor<R,A> : gplex.Absyn.Term.Visitor<R,A>
  {
    public abstract R Visit(gplex.Absyn.TermIdent termident_, A arg);
 
    public abstract R Visit(gplex.Absyn.TermInteger terminteger_, A arg);
  }
  #endregion
  
  #region Token types

  #endregion
}
