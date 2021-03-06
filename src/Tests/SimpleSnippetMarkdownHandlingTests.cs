﻿using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using VerifyXunit;
using MarkdownSnippets;
using Xunit;
using Xunit.Abstractions;

public class SimpleSnippetMarkdownHandlingTests :
    VerifyBase
{
    [Fact]
    public Task AppendGroup()
    {
        var builder = new StringBuilder();
        var snippets = new List<Snippet> {Snippet.Build(1, 2, "theValue", "thekey", "thelanguage", "thePath")};
        using (var writer = new StringWriter(builder))
        {
            SimpleSnippetMarkdownHandling.AppendGroup("key1", snippets, writer.WriteLine);
        }

        return Verify(builder.ToString());
    }

    public SimpleSnippetMarkdownHandlingTests(ITestOutputHelper output) :
        base(output)
    {
    }
}