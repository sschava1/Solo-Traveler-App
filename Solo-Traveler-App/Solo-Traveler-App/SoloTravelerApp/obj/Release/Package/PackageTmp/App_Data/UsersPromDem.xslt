<xsl:stylesheet version="1.0"
xmlns:xsl="http://www.w3.org/1999/XSL/Transform">

  <xsl:template match="/">
    <html>
      <head>
        <title>Entity Information</title>
      </head>
      <body align ="center">
        <h2>Users Information</h2>
        <table border="2" align ="center">
          <tr bgcolor="#9acd32">
            <th>First Name</th>
            <th>Last Name</th>
            <th>Id</th>
            <th>Role</th>
          </tr>
          <xsl:for-each select="Users/User">
            <tr>
              <td>
                <xsl:value-of select="Name/First"/>
              </td>
              <td>
                <xsl:value-of select="Name/Last"/>
              </td>
              <td>
                <xsl:value-of select="Credential/Id"/>
              </td>
              <td>User</td>
            </tr>
          </xsl:for-each>
        </table>
      </body>
    </html>
  </xsl:template>

</xsl:stylesheet>