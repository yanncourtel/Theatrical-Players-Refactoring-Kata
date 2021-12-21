using ApprovalTests;
using ApprovalTests.Reporters;

using System;
using System.Collections.Generic;

using Xunit;

namespace TheatricalPlayersRefactoringKata.Tests;

public class StatementPrinterTests
{
    Dictionary<string, Play> plays = new()
    {
        { "hamlet", new Play("Hamlet", "tragedy") },
        { "as-like", new Play("As You Like It", "comedy") },
        { "henry-v", new Play("Henry V", "history") },
        { "othello", new Play("Othello", "tragedy") },
        { "aslike", new Play("As You Like It", "pastoral")}
    };

    [Fact]
    [UseReporter(typeof(DiffReporter))]
    public void test_statement_example()
    {
        Invoice invoice = new Invoice("BigCo", 
            new List<Performance>{
                new(55, plays["hamlet"]),
                new(35, plays["as-like"]),
                new(40, plays["othello"])});
        StatementPrinter statementPrinter = new StatementPrinter();
        var result = statementPrinter.Print(invoice);

        Approvals.Verify(result);
    }
    [Fact]
    public void test_statement_with_new_play_types()
    {
        Invoice invoice = new Invoice("BigCoII", new List<Performance>
        {
            new(53, plays["henry-v"]),
            new(55, plays["as-like"])
        });

        StatementPrinter statementPrinter = new StatementPrinter();

        Assert.Throws<Exception>(() => statementPrinter.Print(invoice));
    }
}