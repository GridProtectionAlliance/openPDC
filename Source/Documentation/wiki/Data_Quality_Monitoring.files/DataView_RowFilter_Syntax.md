<html xmlns="http://www.w3.org/1999/xhtml" xml:lang="en" lang="en">
<head>
<meta http-equiv="content-type" content="text/html; charset=utf-8" />
<title>DataView RowFilter Syntax [C#]</title>
</head>
<body>
<!--HtmlToGmd.Body-->
<div id="NavigationMenu">
<table style="width: 100%; border-collapse: collapse; border: 0px solid gray;">
<tr>
<td style="width: 25%; text-align:center;"><b><a href="http://www.gridprotectionalliance.org">Grid Protection Alliance</a></b></td>
<td style="width: 25%; text-align:center;"><b><a href="https://github.com/GridProtectionAlliance/openPDC">openPDC Project on GitHub</a></b></td>
<td style="width: 25%; text-align:center;"><b><a href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/openPDC_Home.md">openPDC Wiki Home</a></b></td>
<td style="width: 25%; text-align:center;"><b><a href="https://github.com/GridProtectionAlliance/openPDC/tree/master/Source/Documentation/wiki/openPDC_Documentation_Home.md">Documentation</a></b></td>
</tr>
</table>
</div>
<hr />
<!--/HtmlToGmd.Body-->
<a href="http://www.csharp-examples.net"><img src="https://github.com/GridProtectionAlliance/openPDC/blob/master/Source/Documentation/wiki/Data_Quality_Monitoring.files/csharp-examples.png" width="790" height="120" alt="C# Examples" /></a>
<div id="content">
<h1>DataView RowFilter Syntax [C#]</h1>

<p>This example describes syntax of <a
href="http://msdn2.microsoft.com/en-us/library/system.data.dataview.rowfilter.aspx">DataView.RowFilter</a>
expression. It shows how to correctly build expression string (without „SQL
injection“) using methods to escape values.</p>

<h2>Column names</h2>

<p>If a column name contains any of these special characters <code>~</code>
<code>(</code> <code>)</code> <code>#</code> <code>\</code> <code>/</code>
<code>=</code> <code>&gt;</code> <code>&lt;</code> <code>+</code> <code>-</code>
<code>*</code> <code>%</code> <code>&amp;</code> <code>|</code> <code>^</code>
<code>'</code> <code>"</code> <code>[</code> <code>]</code>, you must enclose
the column name within square brackets <code>[</code> <code>]</code>. If a
column name contains right bracket <code>]</code> or backslash <code>\</code>,
escape it with backslash (<code>\]</code> or <code>\\</code>).</p>
[C#]<br />

<pre class="code">
dataView.RowFilter = <span
class="string">"id = 10"</span>;      <span
class="comments">// no special character in column name "id"</span>
dataView.RowFilter = <span
class="string">"$id = 10"</span>;     <span
class="comments">// no special character in column name "$id"</span>
dataView.RowFilter = <span
class="string">"[#id] = 10"</span>;   <span
class="comments">// special character "#" in column name "#id"</span>
dataView.RowFilter = <span
class="string">"[[id\]] = 10"</span>; <span
class="comments">// special characters in column name "[id]"</span>

</pre>

<h2>Literals</h2>

<p><strong>String values</strong> are enclosed within single quotes
<code>'</code> <code>'</code>. If the string contains single quote
<code>'</code>, the quote must be doubled.</p>
[C#]<br />

<pre class="code">
dataView.RowFilter = <span
class="string">"Name = 'John'"</span>        <span
class="comments">// string value</span>
dataView.RowFilter = <span
class="string">"Name = 'John ''A'''"</span>  <span
class="comments">// string with single quotes "John 'A'"</span>

dataView.RowFilter = <span
class="type">String</span>.Format(<span
class="string">"Name = '{0}'"</span>, <span
class="string">"John 'A'"</span>.Replace(<span class="string">"'"</span>, <span
class="string">"''"</span>));

</pre>

<p><strong>Number values</strong> are not enclosed within any characters. The
values should be the same as is the result of <code>int.ToString()</code> or
<code>float.ToString()</code> method for invariant or English culture.</p>
[C#]<br />

<pre class="code">
dataView.RowFilter = <span
class="string">"Year = 2008"</span>          <span
class="comments">// integer value</span>
dataView.RowFilter = <span
class="string">"Price = 1199.9"</span>       <span
class="comments">// float value</span>

dataView.RowFilter = <span
class="type">String</span>.Format(<span
class="type">CultureInfo</span>.InvariantCulture.NumberFormat,
                     <span
class="string">"Price = {0}"</span>, 1199.9f);

</pre>

<p><strong>Date values</strong> are enclosed within sharp characters
<code>#</code> <code>#</code>. The date format is the same as is the result of
<code>DateTime.ToString()</code> method for invariant or English culture.</p>
[C#]<br />

<pre class="code">
dataView.RowFilter = <span
class="string">"Date = #12/31/2008#"</span>          <span
class="comments">// date value (time is 00:00:00)</span>
dataView.RowFilter = <span
class="string">"Date = #2008-12-31#"</span>          <span
class="comments">// also this format is supported</span>
dataView.RowFilter = <span
class="string">"Date = #12/31/2008 16:44:58#"</span> <span
class="comments">// date and time value</span>

dataView.RowFilter = <span
class="type">String</span>.Format(<span
class="type">CultureInfo</span>.InvariantCulture.DateTimeFormat,
                     <span
class="string">"Date = #{0}#"</span>, <span class="keyword">new</span> <span
class="type">DateTime</span>(2008, 12, 31, 16, 44, 58));

</pre>

<p><strong>Alternatively</strong> you can enclose all values within single
quotes <code>'</code> <code>'</code>. It means you can <strong>use string
values</strong> for numbers or date time values. In this case the current
culture is used to convert the string to the specific value.</p>
[C#]<br />

<pre class="code">
dataView.RowFilter = <span
class="string">"Date = '12/31/2008 16:44:58'"</span> <span
class="comments">// if current culture is English</span>
dataView.RowFilter = <span
class="string">"Date = '31.12.2008 16:44:58'"</span> <span
class="comments">// if current culture is German</span>

dataView.RowFilter = <span
class="string">"Price = '1199.90'"</span>            <span
class="comments">// if current culture is English</span>
dataView.RowFilter = <span
class="string">"Price = '1199,90'"</span>            <span
class="comments">// if current culture is German</span>

</pre>

<h2>Comparison operators</h2>

<p><strong>Equal, not equal, less, greater</strong> operators are used to
include only values that suit to a comparison expression. You can use these
operators <code>=</code> <code>&lt;&gt;</code> <code>&lt;</code>
<code>&lt;=</code> <code>&gt;</code> <code>&gt;=</code>.</p>

<p>Note: <strong>String comparison</strong> is
<strong>culture-sensitive</strong>, it uses CultureInfo from <a
href="http://msdn2.microsoft.com/en-us/library/system.data.datatable.locale.aspx">DataTable.Locale</a>
property of related table (<code>dataView.Table.Locale</code>). If the property
is not explicitly set, its default value is DataSet.Locale (and its default
value is current system culture Thread.Curren­tThread.Curren­tCulture).</p>
[C#]<br />

<pre class="code">
dataView.RowFilter = <span
class="string">"Num = 10"</span>             <span
class="comments">// number is equal to 10</span>
dataView.RowFilter = <span
class="string">"Date &lt; #1/1/2008#"</span>    <span
class="comments">// date is less than 1/1/2008</span>
dataView.RowFilter = <span
class="string">"Name &lt;&gt; 'John'"</span>       <span
class="comments">// string is not equal to 'John'</span>
dataView.RowFilter = <span
class="string">"Name &gt;= 'Jo'"</span>         <span
class="comments">// string comparison</span>

</pre>

<p><strong>Operator IN</strong> is used to include only values from the list.
You can use the operator for all data types, such as numbers or strings.</p>
[C#]<br />

<pre class="code">
dataView.RowFilter = <span
class="string">"Id IN (1, 2, 3)"</span>                    <span
class="comments">// integer values</span>
dataView.RowFilter = <span
class="string">"Price IN (1.0, 9.9, 11.5)"</span>          <span
class="comments">// float values</span>
dataView.RowFilter = <span
class="string">"Name IN ('John', 'Jim', 'Tom')"</span>     <span
class="comments">// string values</span>
dataView.RowFilter = <span
class="string">"Date IN (#12/31/2008#, #1/1/2009#)"</span> <span
class="comments">// date time values</span>

dataView.RowFilter = <span
class="string">"Id NOT IN (1, 2, 3)"</span>  <span
class="comments">// values not from the list</span>

</pre>

<p><strong>Operator LIKE</strong> is used to include only values that match a
pattern with wildcards. <strong>Wildcard</strong> character is <code>*</code> or
<code>%</code>, it can be at the beginning of a pattern <code>'*value'</code>,
at the end <code>'value*'</code>, or at both <code>'*value*'</code>. Wildcard in
the middle of a patern <code>'va*lue'</code> is <strong>not
allowed</strong>.</p>
[C#]<br />

<pre class="code">
dataView.RowFilter = <span
class="string">"Name LIKE 'j*'"</span>       <span
class="comments">// values that start with 'j'</span>
dataView.RowFilter = <span
class="string">"Name LIKE '%jo%'"</span>     <span
class="comments">// values that contain 'jo'</span>

dataView.RowFilter = <span
class="string">"Name NOT LIKE 'j*'"</span>   <span
class="comments">// values that don't start with 'j'</span>

</pre>

<p>If a pattern in a LIKE clause contains any of these special characters
<code>*</code> <code>%</code> <code>[</code> <code>]</code>, those characters
must be escaped in brackets <code>[</code> <code>]</code> like this
<code>[*]</code>, <code>[%]</code>, <code>[[]</code> or <code>[]]</code>.</p>
[C#]<br />

<pre class="code">
dataView.RowFilter = <span
class="string">"Name LIKE '[*]*'"</span>     <span
class="comments">// values that starts with '*'</span>
dataView.RowFilter = <span
class="string">"Name LIKE '[[]*'"</span>     <span
class="comments">// values that starts with '['</span>

</pre>

<p>The following method escapes a text value for usage in a LIKE clause.</p>
[C#]<br />

<pre class="code">
<span
class="keyword">public static string</span> <strong>EscapeLikeValue</strong>(<span
class="keyword">string</span> valueWithoutWildcards)
{
  <span
class="type">StringBuilder</span> sb = <span class="keyword">new</span> <span
class="type">StringBuilder</span>();
  <span class="keyword">for</span> (<span
class="keyword">int</span> i = 0; i &lt; valueWithoutWildcards.Length; i++)
  {
    <span
class="keyword">char</span> c = valueWithoutWildcards[i];
    <span
class="keyword">if</span> (c == <span class="string">'*'</span> || c == <span
class="string">'%'</span> || c == <span class="string">'['</span> || c == <span
class="string">']'</span>)
      sb.Append(<span
class="string">"["</span>).Append(c).Append(<span
class="string">"]"</span>);
    <span class="keyword">else if</span> (c == <span
class="string">'\''</span>)
      sb.Append(<span
class="string">"''"</span>);
    <span
class="keyword">else</span>
      sb.Append(c);
  }
  <span
class="keyword">return</span> sb.ToString();
}

</pre>
 [C#]<br />

<pre class="code">
<span
class="comments">// select all that starts with the value string (in this case with "*")</span>
<span
class="keyword">string</span> value = <span class="string">"*"</span>;
<span
class="comments">// the dataView.RowFilter will be: "Name LIKE '[*]*'"</span>
dataView.RowFilter = <span
class="type">String</span>.Format(<span
class="string">"Name LIKE '{0}*'"</span>, <strong>EscapeLikeValue</strong>(value));

</pre>

<h2>Boolean operators</h2>

<p>Boolean operators <code>AND</code>, <code>OR</code> and <code>NOT</code> are
used to concatenate expressions. Operator NOT has precedence over AND operator
and it has precedence over OR operator.</p>
[C#]<br />

<pre class="code">
<span
class="comments">// operator AND has precedence over OR operator, parenthesis are needed</span>
dataView.RowFilter = <span
class="string">"City = 'Tokyo' AND (Age &lt; 20 OR Age &gt; 60)"</span>;

<span
class="comments">// following examples do the same</span>
dataView.RowFilter = <span
class="string">"City &lt;&gt; 'Tokyo' AND City &lt;&gt; 'Paris'"</span>;
dataView.RowFilter = <span
class="string">"NOT City = 'Tokyo' AND NOT City = 'Paris'"</span>;
dataView.RowFilter = <span
class="string">"NOT (City = 'Tokyo' OR City = 'Paris')"</span>;
dataView.RowFilter = <span
class="string">"City NOT IN ('Tokyo', 'Paris')"</span>;

</pre>

<h2>Arithmetic and string operators</h2>

<p><strong>Arithmetic operators</strong> are addition <code>+</code>,
subtraction <code>-</code>, multiplication <code>*</code>, division
<code>/</code> and modulus <code>%</code>.</p>
[C#]<br />

<pre class="code">
dataView.RowFilter = <span
class="string">"MotherAge - Age &lt; 20"</span>;   <span
class="comments">// people with young mother</span>
dataView.RowFilter = <span
class="string">"Age % 10 = 0"</span>;           <span
class="comments">// people with decennial birthday</span>

</pre>

<p>There is also one <strong>string</strong> operator
<strong>concatenation</strong> <code>+</code>.</p>

<h2>Parent-Child Relation Referencing</h2>

<p>A <strong>parent table</strong> can be referenced in an expression using
parent column name with <code>Parent.</code> prefix. A column in a
<strong>child table</strong> can be referenced using child column name with
<code>Child.</code> prefix.</p>

<p>The reference to the child column must be in an <strong>aggregate
function</strong> because child relationships may return multiple rows. For
example expression <code>SUM(Child.Price)</code> returns sum of all prices in
child table related to the row in parent table.</p>

<p>If a table has more than one child relation, the prefix must contain relation
name. For example expression <code>Child(OrdersToItemsRelation).Price</code>
references to column Price in child table using relation named
OrdersToItemsRe­lation.</p>

<h2>Aggregate Functions</h2>

<p>There are supported following aggregate functions <code>SUM</code>,
<code>COUNT</code>, <code>MIN</code>, <code>MAX</code>, <code>AVG</code>
(average), <code>STDEV</code> (statistical standard deviation) and
<code>VAR</code> (statistical variance).</p>

<p>This example shows aggregate function performed on a single table.</p>
[C#]<br />

<pre class="code">
<span
class="comments">// select people with above-average salary</span>
dataView.RowFilter = <span
class="string">"Salary &gt; AVG(Salary)"</span>;

</pre>

<p>Following example shows aggregate functions performed on two tables which
have parent-child relation. Suppose there are tables Orders and Items with the
parent-child relation.</p>
[C#]<br />

<pre class="code">
<span
class="comments">// select orders which have more than 5 items</span>
dataView.RowFilter = <span
class="string">"COUNT(Child.IdOrder) &gt; 5"</span>;

<span
class="comments">// select orders which total price (sum of items prices) is greater or equal $500</span>
dataView.RowFilter = <span
class="string">"SUM(Child.Price) &gt;= 500"</span>;

</pre>

<h2>Functions</h2>

<p>There are also supported following functions. Detailed description can be
found here <a
href="http://msdn2.microsoft.com/en-us/library/system.data.datacolumn.expression.aspx">DataColumn.Ex­pression</a>.</p>

<ul>
	<li><code>CONVERT</code> – converts particular expression to a specified .NET
	Framework type</li>

	<li><code>LEN</code> – gets the length of a string</li>

	<li><code>ISNULL</code> – checks an expression and either returns the checked
	expression or a replacement value</li>

	<li><code>IIF</code> – gets one of two values depending on the result of a
	logical expression</li>

	<li><code>TRIM</code> – removes all leading and trailing blank characters
	like \r, \n, \t, ‚ ‘</li>

	<li><code>SUBSTRING</code> – gets a sub-string of a specified length,
	starting at a specified point in the string</li>
</ul>

    <h2>See also</h2>

<ul>
	<li><a
	href="http://msdn2.microsoft.com/en-us/library/system.data.dataview.rowfilter.aspx">DataView.RowFil­ter</a> –
	MSDN – expression used to filter rows</li>

	<li><a
	href="http://msdn2.microsoft.com/en-us/library/system.data.datacolumn.expression.aspx">DataColumn.Ex­pression</a> –
	MSDN – syntax description</li>
</ul>

<p class="author">By <a href="/jan-slama/">Jan Slama</a>, 15-Mar-2008</p>

<!-- by Texy2! --></div>
<div id="footer">
<hr />
Copyright &copy; 2010 Jan Slama. </div>
</div>
</body>
</html>

