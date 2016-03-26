//C# Abstract Syntax Interface generated by the BNF Converter.
using System;
using System.Collections.Generic;
namespace gplex.Absyn
{
  #region Token Classes
  public class TokenBaseType
  {
    private string str;
    
    public TokenBaseType(string str)
    {
      this.str = str;
    }
    
    public override string ToString()
    {
      return this.str;
    }
  }
  
  #endregion
  
  #region Abstract Syntax Classes
  public abstract class Expr
  {
    public abstract R Accept<R,A>(gplex.Absyn.Expr.Visitor<R,A> v, A arg);
    
    public interface Visitor<R,A>
    {
      R Visit(gplex.Absyn.Expr1 p, A arg);
      R Visit(gplex.Absyn.ExprTerm p, A arg);
    }
  }
 
  public abstract class Term
  {
    public abstract R Accept<R,A>(gplex.Absyn.Term.Visitor<R,A> v, A arg);
    
    public interface Visitor<R,A>
    {
      R Visit(gplex.Absyn.TermIdent p, A arg);
      R Visit(gplex.Absyn.TermInteger p, A arg);
    }
  }
  
  public class Expr1 : gplex.Absyn.Expr
  {
    private gplex.Absyn.Term term_1;
    private gplex.Absyn.Term term_2;

    public Expr1(gplex.Absyn.Term p1, gplex.Absyn.Term p2)
    {
      term_1 = p1;
      term_2 = p2;
    }
    
    public gplex.Absyn.Term Term_1
    {
      get
      {
        return this.term_1;
      }
      set
      {
        this.term_1 = value;
      }
    }
    
    public gplex.Absyn.Term Term_2
    {
      get
      {
        return this.term_2;
      }
      set
      {
        this.term_2 = value;
      }
    }
    
    public override bool Equals(Object obj)
    {
      if(this == obj)
      {
        return true;
      }
      if(obj is gplex.Absyn.Expr1)
      {
        return this.Equals((gplex.Absyn.Expr1)obj);
      }
      return base.Equals(obj);
    }
    
    public bool Equals(gplex.Absyn.Expr1 obj)
    {
      if(this == obj)
      {
        return true;
      }
      return this.Term_1.Equals(obj.Term_1) && this.Term_2.Equals(obj.Term_2);
    }
    
    public override int GetHashCode()
    {
      return 37*(this.Term_1.GetHashCode())+this.Term_2.GetHashCode();
    }
    
    public override R Accept<R,A>(gplex.Absyn.Expr.Visitor<R,A> visitor, A arg)
    {
      return visitor.Visit(this, arg);
    }
  }
 
  public class ExprTerm : gplex.Absyn.Expr
  {
    private gplex.Absyn.Term term_;

    public ExprTerm(gplex.Absyn.Term p1)
    {
      term_ = p1;
    }
    
    public gplex.Absyn.Term Term_
    {
      get
      {
        return this.term_;
      }
      set
      {
        this.term_ = value;
      }
    }
    
    public override bool Equals(Object obj)
    {
      if(this == obj)
      {
        return true;
      }
      if(obj is gplex.Absyn.ExprTerm)
      {
        return this.Equals((gplex.Absyn.ExprTerm)obj);
      }
      return base.Equals(obj);
    }
    
    public bool Equals(gplex.Absyn.ExprTerm obj)
    {
      if(this == obj)
      {
        return true;
      }
      return this.Term_.Equals(obj.Term_);
    }
    
    public override int GetHashCode()
    {
      return this.Term_.GetHashCode();
    }
    
    public override R Accept<R,A>(gplex.Absyn.Expr.Visitor<R,A> visitor, A arg)
    {
      return visitor.Visit(this, arg);
    }
  }
 
  public class TermIdent : gplex.Absyn.Term
  {
    private string ident_;

    public TermIdent(string p1)
    {
      ident_ = p1;
    }
    
    public string Ident_
    {
      get
      {
        return this.ident_;
      }
      set
      {
        this.ident_ = value;
      }
    }
    
    public override bool Equals(Object obj)
    {
      if(this == obj)
      {
        return true;
      }
      if(obj is gplex.Absyn.TermIdent)
      {
        return this.Equals((gplex.Absyn.TermIdent)obj);
      }
      return base.Equals(obj);
    }
    
    public bool Equals(gplex.Absyn.TermIdent obj)
    {
      if(this == obj)
      {
        return true;
      }
      return this.Ident_.Equals(obj.Ident_);
    }
    
    public override int GetHashCode()
    {
      return this.Ident_.GetHashCode();
    }
    
    public override R Accept<R,A>(gplex.Absyn.Term.Visitor<R,A> visitor, A arg)
    {
      return visitor.Visit(this, arg);
    }
  }
 
  public class TermInteger : gplex.Absyn.Term
  {
    private int integer_;

    public TermInteger(int p1)
    {
      integer_ = p1;
    }
    
    public int Integer_
    {
      get
      {
        return this.integer_;
      }
      set
      {
        this.integer_ = value;
      }
    }
    
    public override bool Equals(Object obj)
    {
      if(this == obj)
      {
        return true;
      }
      if(obj is gplex.Absyn.TermInteger)
      {
        return this.Equals((gplex.Absyn.TermInteger)obj);
      }
      return base.Equals(obj);
    }
    
    public bool Equals(gplex.Absyn.TermInteger obj)
    {
      if(this == obj)
      {
        return true;
      }
      return this.Integer_.Equals(obj.Integer_);
    }
    
    public override int GetHashCode()
    {
      return this.Integer_.GetHashCode();
    }
    
    public override R Accept<R,A>(gplex.Absyn.Term.Visitor<R,A> visitor, A arg)
    {
      return visitor.Visit(this, arg);
    }
  }
  
  #region Lists
  #endregion
  #endregion
}
