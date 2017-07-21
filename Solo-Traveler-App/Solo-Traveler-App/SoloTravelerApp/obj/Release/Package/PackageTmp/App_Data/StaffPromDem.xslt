<xsl:stylesheet version="1.0"
xmlns:xsl="http://www.w3.org/1999/XSL/Transform">

  <xsl:template match="/">
    <html>
      <body>
        <table border="2" align ="center">
          <h2>Staff Information</h2>
          <tr bgcolor="#9acd32">
            <th>First Name</th>
            <th>Last Name</th>
            <th>Id</th>
            <th>Role</th>
          </tr>
          <xsl:for-each select="Staff/Member">
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
              <td>
                <xsl:value-of select="Role"/>
              </td>
            </tr>
          </xsl:for-each>
    </table>
    </body>
    </html>
  </xsl:template>

</xsl:stylesheet>