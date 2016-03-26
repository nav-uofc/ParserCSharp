using System;
using System.Collections.Generic;
using System.CodeDom.Compiler;
using System.Globalization;
using System.Text;
using QUT.Gppg;

namespace gplex
{
public enum Tokens {error=2,EOF=3,SYMB_0=4,INTEGER_=5,IDENT_=6};

public struct ValueType
#line 35 "gplex.y"
{
  public int int_;
  public char char_;
  public double double_;
  public string string_;
  public gplex.Absyn.Expr expr_;
  public gplex.Absyn.Term term_;
}
#line default
// Abstract base class for GPLEX scanners
[GeneratedCodeAttribute( "Gardens Point Parser Generator", "1.5.2")]
public abstract class ScanBase : AbstractScanner<ValueType,LexLocation> {
  private LexLocation __yylloc = new LexLocation();
  public override LexLocation yylloc { get { return __yylloc; } set { __yylloc = value; } }
  protected virtual bool yywrap() { return true; }
}

// Utility class for encapsulating token information
[GeneratedCodeAttribute( "Gardens Point Parser Generator", "1.5.2")]
public class ScanObj {
  public int token;
  public ValueType yylval;
  public LexLocation yylloc;
  public ScanObj( int t, ValueType val, LexLocation loc ) {
    this.token = t; this.yylval = val; this.yylloc = loc;
  }
}

[GeneratedCodeAttribute( "Gardens Point Parser Generator", "1.5.2")]
public class Parser: ShiftReduceParser<ValueType, LexLocation>
{
    public Parser(Scanner scnr) : base(scnr) { }

  // Verbatim content from gplex.y - 03/25/2016 19:52:11
#line 5 "gplex.y"

  gplex.Absyn.Expr YY_RESULT_Expr_ = null;
  public gplex.Absyn.Expr ParseExpr()
  {
    if(this.Parse())
    {
      return YY_RESULT_Expr_;
    }
    else
    {
      throw new Exception("Could not parse input stream!");
    }
  }
  
  gplex.Absyn.Term YY_RESULT_Term_ = null;
  public gplex.Absyn.Term ParseTerm()
  {
    if(this.Parse())
    {
      return YY_RESULT_Term_;
    }
    else
    {
      throw new Exception("Could not parse input stream!");
    }
  }
  
#line default
  // End verbatim content from gplex.y - 03/25/2016 19:52:11

#pragma warning disable 649
  private static Dictionary<int, string> aliases;
#pragma warning restore 649
  private static Rule[] rules = new Rule[6];
  private static State[] states = new State[8];
  private static string[] nonTerms = new string[] {
      "Expr", "Term", "$accept", };

  static Parser() {
    states[0] = new State(new int[]{6,6,5,7},new int[]{-1,1,-2,3});
    states[1] = new State(new int[]{3,2});
    states[2] = new State(-1);
    states[3] = new State(new int[]{4,4,3,-3});
    states[4] = new State(new int[]{6,6,5,7},new int[]{-2,5});
    states[5] = new State(-2);
    states[6] = new State(-4);
    states[7] = new State(-5);

    for (int sNo = 0; sNo < states.Length; sNo++) states[sNo].number = sNo;

    rules[1] = new Rule(-3, new int[]{-1,3});
    rules[2] = new Rule(-1, new int[]{-2,4,-2});
    rules[3] = new Rule(-1, new int[]{-2});
    rules[4] = new Rule(-2, new int[]{6});
    rules[5] = new Rule(-2, new int[]{5});
  }

  protected override void Initialize() {
    this.InitSpecialTokens((int)Tokens.error, (int)Tokens.EOF);
    this.InitStates(states);
    this.InitRules(rules);
    this.InitNonTerminals(nonTerms);
  }

  protected override void DoAction(int action)
  {
#pragma warning disable 162, 1522
    switch (action)
    {
      case 2: // Expr -> Term, SYMB_0, Term
#line 53 "gplex.y"
                        {  CurrentSemanticValue.expr_ = new gplex.Absyn.Expr1(ValueStack[ValueStack.Depth-3].term_,ValueStack[ValueStack.Depth-1].term_); YY_RESULT_Expr_= CurrentSemanticValue.expr_; }
#line default
        break;
      case 3: // Expr -> Term
#line 54 "gplex.y"
         {  CurrentSemanticValue.expr_ = new gplex.Absyn.ExprTerm(ValueStack[ValueStack.Depth-1].term_); YY_RESULT_Expr_= CurrentSemanticValue.expr_; }
#line default
        break;
      case 4: // Term -> IDENT_
#line 56 "gplex.y"
              {  CurrentSemanticValue.term_ = new gplex.Absyn.TermIdent(ValueStack[ValueStack.Depth-1].string_); YY_RESULT_Term_= CurrentSemanticValue.term_; }
#line default
        break;
      case 5: // Term -> INTEGER_
#line 57 "gplex.y"
             {  CurrentSemanticValue.term_ = new gplex.Absyn.TermInteger(ValueStack[ValueStack.Depth-1].int_); YY_RESULT_Term_= CurrentSemanticValue.term_; }
#line default
        break;
    }
#pragma warning restore 162, 1522
  }

  protected override string TerminalToString(int terminal)
  {
    if (aliases != null && aliases.ContainsKey(terminal))
        return aliases[terminal];
    else if (((Tokens)terminal).ToString() != terminal.ToString(CultureInfo.InvariantCulture))
        return ((Tokens)terminal).ToString();
    else
        return CharToString((char)terminal);
  }

}
}
