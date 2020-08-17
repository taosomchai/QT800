
Public Class Form1
    Private Sub Form1_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        If SerialPort1.IsOpen Then
            SerialPort1.Close()
        End If
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not SerialPort1.IsOpen Then
            SerialPort1.Open()
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If SerialPort1.IsOpen Then
            'SerialPort1.Write("^XA^LH30,30\n^FO20,10^ADN,90,50^AD^FD......................Hello thasika^FS\n^XZ")
            'SerialPort1.Write("^XA^FO10,10,^AO,30,20^FDFDTesting^FS^FO10,30^BY3^BCN,100,Y,N,N^FDTesting^FS^XZ")
            'SerialPort1.Write("^XA^LH0,0^FO50,50^BXN,5,200^FD0101111452628888888888888817170730108880^FS^FO168,50^AE,18,10^FPH\^FDNAME:^FS^FO265,50^AEN,18,10^FPH\^FDTEST NAME^FS^FO168,80^AEN,18,10^FPH\^FDTUID:^FS^FO265,80^AEN,18,10^FPH\^FD88888888889000^FS^FO168,110^AEN,18,10^FPH\^FDDATE:^FS^FO265,110^AEN,18,10^FPH\^FD+4108374-11-11^FS^FO168,140^AEN,18,10^FPH\^FDAGE:^FS^FO265,140^AEN,18,10^FPH\^FDTEST LOT^FS^XZ")

            '----- QR Code -----
            'SerialPort1.Write("^XA")
            'SerialPort1.Write("^FO250,20")  'position x, y
            'SerialPort1.Write("^BQ,2,10^FDQA,0123456789ABCD 2D code^FS")
            ''SerialPort1.Write("^BQ,2,10^FMMA,0123456789ABCD 2D code^FS")
            'SerialPort1.Write("^XZ")

            '----- DataMatrix -------
            SerialPort1.Write("^XA")
            SerialPort1.Write("^FO250,0")
            SerialPort1.Write("^BXN,3,200")
            SerialPort1.Write("^FD")
            SerialPort1.Write(txtDM.Text)
            SerialPort1.Write("^FS")

            '----- Text -------
            'SerialPort1.Write("^XA")
            SerialPort1.Write("^FO380,0")
            SerialPort1.Write("^A0,32,25")
            SerialPort1.Write("^FD")
            SerialPort1.Write("JABIR")
            SerialPort1.Write("^FS")

            SerialPort1.Write("^FO340,30")
            SerialPort1.Write("^A0,32,18")
            SerialPort1.Write("^FD")
            SerialPort1.Write(txtDM.Text)
            SerialPort1.Write("^FS")


            SerialPort1.Write("^XZ")

            SerialPort1.Write("I8,A,001\n\n\nQ0001,0\nq831\nrN\nS5\nD10\nZT\nJF\nO\nR20,0\nf100\nN\nB775,188,2,1,2,6,160,B,\""SM00020000\"",199,1,0,200\nP1\n")

            'SerialPort1.Write("^xa^aa^fd ^fs^xz")

        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim index As Integer

        If SerialPort1.IsOpen Then
            'SerialPort1.WriteLine("I8,1,001")
            'SerialPort1.WriteLine("q808")
            'SerialPort1.WriteLine("S3")
            'SerialPort1.WriteLine("ON")
            'SerialPort1.WriteLine("JF")
            'SerialPort1.WriteLine("WN")
            'SerialPort1.WriteLine("D6")
            'SerialPort1.WriteLine("ZB")
            'SerialPort1.WriteLine("Q120,20")
            SerialPort1.WriteLine("N")

            ''print barcode
            'SerialPort1.WriteLine("B70,3,0,1,2,4,64,N,""" & "1" & "122233" & "1" & "1234" & """")
            ''print barcode in number
            'SerialPort1.WriteLine("A72,70,0,1,2,2,N,""" & "1" & "122233" & "1" & "1234" & """")
            ''print rating + performance
            'SerialPort1.WriteLine("A340,14,1,1,2,1,N,""" & "ABCD" & " " & "ZZZZ" & """")

            '----- DataMatrix -------
            '   bp1,p2,p3,[p4,][,p5][,p6][,p7],"DATA"
            '   p1=X, p2=Y
            SerialPort1.WriteLine("b130,0,D,h4,""" & txtDM.Text & """")
            '----- Text -------
            '   Ap1,p2,p3,p4,p5,p6,p7,"DATA"
            '   p1=X, p2=Y, p3=Rotation, p4=font, p5=hor multiplier, p6=ver multiplier, p7=reverse
            SerialPort1.WriteLine("A230,15,0,4,1,1,N,""" & "LRD" & """")

            index = txtDM.Text.IndexOf(" ")
            SerialPort1.WriteLine("A230,50,0,1,1,1,N,""" & Mid(txtDM.Text, 1, index) & """")
            SerialPort1.WriteLine("A230,70,0,1,1,1,N,""" & LTrim(Mid(txtDM.Text, index + 1, 50)) & """")

            SerialPort1.WriteLine("P1")
            SerialPort1.WriteLine("N")
        End If
    End Sub


End Class
