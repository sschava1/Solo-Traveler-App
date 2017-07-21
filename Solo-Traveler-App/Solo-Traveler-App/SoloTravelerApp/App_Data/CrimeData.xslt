<xsl:stylesheet version="1.0"
xmlns:xsl="http://www.w3.org/1999/XSL/Transform">

  <xsl:template match="/">
    <html>
      <head>
        <title>Crime Data</title>
      </head>
      <body>
        <h2>
          Crime Data for area zip: <xsl:value-of select="CrimeData/@zip"/>
        </h2>
        <table border="1" align="center">
          <tr>
            <td bgcolor="#9acd32">Violent Crime</td>
            <td>
              <xsl:value-of select="CrimeData/ViolentCrime"/>
            </td>
          </tr>
          <tr>
            <td bgcolor="#9acd32">Murder And Man slaughter</td>
            <td>
              <xsl:value-of select="CrimeData/MurderAndManslaughter"/>
            </td>
          </tr>
          <tr>
            <td bgcolor="#9acd32">Forcible Rape</td>
            <td>
              <xsl:value-of select="CrimeData/ForcibleRape"/>
            </td>
          </tr>
          <tr>
            <td bgcolor="#9acd32">Robbery</td>
            <td>
              <xsl:value-of select="CrimeData/Robbery"/>
            </td>
          </tr>
          <tr>
            <td bgcolor="#9acd32">Aggravated Assault</td>
            <td>
              <xsl:value-of select="CrimeData/AggravatedAssault"/>
            </td>
          </tr>
          <tr>
            <td bgcolor="#9acd32">Property Crime</td>
            <td>
              <xsl:value-of select="CrimeData/PropertyCrime"/>
            </td>
          </tr>
          <tr>
            <td bgcolor="#9acd32">Burglary</td>
            <td>
              <xsl:value-of select="CrimeData/Burglary"/>
            </td>
          </tr>
          <tr>
            <td bgcolor="#9acd32">Larceny Theft</td>
            <td>
              <xsl:value-of select="CrimeData/LarcenyTheft"/>
            </td>
          </tr>
          <tr>
            <td bgcolor="#9acd32">Motor Vehicle Theft</td>
            <td>
              <xsl:value-of select="CrimeData/MotorVehicleTheft"/>
            </td>
          </tr>
          <tr>
            <td bgcolor="#9acd32">Arson</td>
            <td>
              <xsl:value-of select="CrimeData/Arson"/>
            </td>
          </tr>
        </table>
      </body>
    </html>
  </xsl:template>

</xsl:stylesheet>