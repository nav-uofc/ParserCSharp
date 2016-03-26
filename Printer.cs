/*** BNFC-Generated Pretty Printer and Abstract Syntax Viewer ***/
 
using System;
using System.Text; // for StringBuilder
using gplex.Absyn;
 
namespace gplex
{
  #region Pretty-printer class
  public class PrettyPrinter
  {
    #region Misc rendering functions
    // You may wish to change these:
    private const int BUFFER_INITIAL_CAPACITY = 2000;
    private const int INDENT_WIDTH = 2;
    private const string LEFT_PARENTHESIS = "(";
    private const string RIGHT_PARENTHESIS = ")";
    private static System.Globalization.NumberFormatInfo InvariantFormatInfo = System.Globalization.NumberFormatInfo.InvariantInfo;
    
    private static int _n_ = 0;
    private static StringBuilder buffer = new StringBuilder(BUFFER_INITIAL_CAPACITY);
    
    //You may wish to change render
    private static void Render(String s)
    {
      if(s == "{")
      {
        buffer.Append("\n");
        Indent();
        buffer.Append(s);
        _n_ = _n_ + INDENT_WIDTH;
        buffer.Append("\n");
        Indent();
      }
      else if(s == "(" || s == "[")
        buffer.Append(s);
      else if(s == ")" || s == "]")
      {
        Backup();
        buffer.Append(s);
        buffer.Append(" ");
      }
      else if(s == "}")
      {
        int t;
        _n_ = _n_ - INDENT_WIDTH;
        for(t=0; t<INDENT_WIDTH; t++) {
          Backup();
        }
        buffer.Append(s);
        buffer.Append("\n");
        Indent();
      }
      else if(s == ",")
      {
        Backup();
        buffer.Append(s);
        buffer.Append(" ");
      }
      else if(s == ";")
      {
        Backup();
        buffer.Append(s);
        buffer.Append("\n");
        Indent();
      }
      else if(s == "") return;
      else
      {
        // Make sure escaped characters are printed properly!
        if(s.StartsWith("\"") && s.EndsWith("\""))
        {
          buffer.Append('"');
          StringBuilder sb = new StringBuilder(s);
          // Remove enclosing citation marks
          sb.Remove(0,1);
          sb.Remove(sb.Length-1,1);
          // Note: we have to replace backslashes first! (otherwise it will "double-escape" the other escapes)
          sb.Replace("\\", "\\\\");
          sb.Replace("\n", "\\n");
          sb.Replace("\t", "\\t");
          sb.Replace("\"", "\\\"");
          buffer.Append(sb.ToString());
          buffer.Append('"');
        }
        else
        {
          buffer.Append(s);
        }
        buffer.Append(" ");
      }
    }
    
    private static void PrintInternal(int n, int _i_)
    {
      buffer.Append(n.ToString(InvariantFormatInfo));
      buffer.Append(' ');
    }
    
    private static void PrintInternal(double d, int _i_)
    {
      buffer.Append(d.ToString(InvariantFormatInfo));
      buffer.Append(' ');
    }
    
    private static void PrintInternal(string s, int _i_)
    {
      Render(s);
    }
    
    private static void PrintInternal(char c, int _i_)
    {
      PrintQuoted(c);
    }
    
    
    private static void ShowInternal(int n)
    {
      Render(n.ToString(InvariantFormatInfo));
    }
    
    private static void ShowInternal(double d)
    {
      Render(d.ToString(InvariantFormatInfo));
    }
    
    private static void ShowInternal(char c)
    {
      PrintQuoted(c);
    }
    
    private static void ShowInternal(string s)
    {
      PrintQuoted(s);
    }
    
    
    private static void PrintQuoted(string s)
    {
      Render("\"" + s + "\"");
    }
    
    private static void PrintQuoted(char c)
    {
      // Makes sure the character is escaped properly before printing it.
      string str = c.ToString();
      if(c == '\n') str = "\\n";
      if(c == '\t') str = "\\t";
      Render("'" + str + "'");
    }
    
    private static void Indent()
    {
      int n = _n_;
      while (n > 0)
      {
        buffer.Append(' ');
        n--;
      }
    }
    
    private static void Backup()
    {
      if(buffer[buffer.Length - 1] == ' ')
      {
        buffer.Length = buffer.Length - 1;
      }
    }
    
    private static void Trim()
    {
      while(buffer.Length > 0 && buffer[0] == ' ')
        buffer.Remove(0, 1); 
      while(buffer.Length > 0 && buffer[buffer.Length-1] == ' ')
        buffer.Remove(buffer.Length-1, 1);
    }
    
    private static string GetAndReset()
    {
      Trim();
      string strReturn = buffer.ToString();
      Reset();
      return strReturn;
    }
    
    private static void Reset()
    {
      buffer.Remove(0, buffer.Length);
    }
    #endregion
    
    #region Print Entry Points
    public static string Print(gplex.Absyn.Expr cat)
    {
      PrintInternal(cat, 0);
      return GetAndReset();
    }
 
    public static string Print(gplex.Absyn.Term cat)
    {
      PrintInternal(cat, 0);
      return GetAndReset();
    }
    #endregion
    
    #region Show Entry Points
    public static String Show(gplex.Absyn.Expr cat)
    {
      ShowInternal(cat);
      return GetAndReset();
    }
 
    public static String Show(gplex.Absyn.Term cat)
    {
      ShowInternal(cat);
      return GetAndReset();
    }
    #endregion
    
    #region (Internal) Print Methods
    private static void PrintInternal(gplex.Absyn.Expr p, int _i_)
    {
      if(p is gplex.Absyn.Expr1)
      {
        gplex.Absyn.Expr1 _expr1 = (gplex.Absyn.Expr1)p;
        if(_i_ > 0) Render(LEFT_PARENTHESIS);
        PrintInternal(_expr1.Term_1, 0);
        Render("+");
        PrintInternal(_expr1.Term_2, 0);
        if(_i_ > 0) Render(RIGHT_PARENTHESIS);
      }
      else if(p is gplex.Absyn.ExprTerm)
      {
        gplex.Absyn.ExprTerm _exprterm = (gplex.Absyn.ExprTerm)p;
        if(_i_ > 0) Render(LEFT_PARENTHESIS);
        PrintInternal(_exprterm.Term_, 0);
        if(_i_ > 0) Render(RIGHT_PARENTHESIS);
      }
    }
 
    private static void PrintInternal(gplex.Absyn.Term p, int _i_)
    {
      if(p is gplex.Absyn.TermIdent)
      {
        gplex.Absyn.TermIdent _termident = (gplex.Absyn.TermIdent)p;
        if(_i_ > 0) Render(LEFT_PARENTHESIS);
        PrintInternal(_termident.Ident_, 0);
        if(_i_ > 0) Render(RIGHT_PARENTHESIS);
      }
      else if(p is gplex.Absyn.TermInteger)
      {
        gplex.Absyn.TermInteger _terminteger = (gplex.Absyn.TermInteger)p;
        if(_i_ > 0) Render(LEFT_PARENTHESIS);
        PrintInternal(_terminteger.Integer_, 0);
        if(_i_ > 0) Render(RIGHT_PARENTHESIS);
      }
    }
    #endregion
    
    #region (Internal) Show Methods
    private static void ShowInternal(gplex.Absyn.Expr p)
    {
      if(p is gplex.Absyn.Expr1)
      {
        gplex.Absyn.Expr1 _expr1 = (gplex.Absyn.Expr1)p;
        Render("(");
        Render("Expr1");
        ShowInternal(_expr1.Term_1);
        ShowInternal(_expr1.Term_2);
        Render(")");
      }
      if(p is gplex.Absyn.ExprTerm)
      {
        gplex.Absyn.ExprTerm _exprterm = (gplex.Absyn.ExprTerm)p;
        Render("(");
        Render("ExprTerm");
        ShowInternal(_exprterm.Term_);
        Render(")");
      }
    }
 
    private static void ShowInternal(gplex.Absyn.Term p)
    {
      if(p is gplex.Absyn.TermIdent)
      {
        gplex.Absyn.TermIdent _termident = (gplex.Absyn.TermIdent)p;
        Render("(");
        Render("TermIdent");
        ShowInternal(_termident.Ident_);
        Render(")");
      }
      if(p is gplex.Absyn.TermInteger)
      {
        gplex.Absyn.TermInteger _terminteger = (gplex.Absyn.TermInteger)p;
        Render("(");
        Render("TermInteger");
        ShowInternal(_terminteger.Integer_);
        Render(")");
      }
    }
    #endregion
  }
  #endregion
}
