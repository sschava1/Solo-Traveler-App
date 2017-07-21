<xsl:stylesheet version="1.0"
xmlns:xsl="http://www.w3.org/1999/XSL/Transform">

  <xsl:template match="/">
    <html>
      <head>
        <title>Nearest Store Table</title>
      </head>
      <body>
        <h2>Nearest Stores Information</h2>
        <table border="2" align="center">
          <tr bgcolor="#9acd32">
            <th>Name</th>
            <th>Address</th>
          </tr>
          <xsl:for-each select="StoreData/result">
            <tr>
              <td>
                <xsl:value-of select="name"/>
              </td>
              <td>
                <xsl:value-of select="vicinity"/>
              </td>
            </tr>
          </xsl:for-each>
        </table>
      </body>
    </html>
  </xsl:template>

</xsl:stylesheet>