Imports System.IO
Public Class Graficadora
    Dim ListaClases As New List(Of Clase)
    Dim ListaAtributos As New List(Of Atributos)
    Dim ListaMetodos As New List(Of Metodos)
    Dim ListaComentario = New List(Of Comentario)
    Dim Relacion As New List(Of Relacion)
    Dim RelacionComen As New List(Of Relacion)
    Dim TextoRelacion As String
    Public Const PR6 As String = "Herencia"
    Public Const PR7 As String = "Agregacion"
    Public Const PR8 As String = "Composicion"
    Public Const PR9 As String = "AsociacionSimple"

    Public Sub CrearDot(clases As String)
        Try
            Dim ruta As String = "UML.dot"
            Dim sw As StreamWriter = New StreamWriter(ruta)
            sw.Write("digraph uml{ node[shape=record,style=filled,fillcolor=gray95]  edge[dir=back,arrowtail=empty] ")
            sw.Write(clases)
            sw.Write("}")
            sw.Flush()
            sw.Close()
        Catch ex As Exception
        End Try
    End Sub
    Public Sub GenerarImagen()
        Dim doPath As String = "D:\Programas\Graphviz\bin\dot.exe"
        Dim cmd As String = doPath & " -Tjpg " & "UML.dot" & " -o " & "diagrama.jpg"
        Dim prog As VariantType
        prog = Shell(cmd, 1)
    End Sub
    Public Sub Limpiar()
        ListaClases.Clear()
        Relacion.Clear()
        RelacionComen.Clear()
        ListaMetodos.Clear()
        ListaAtributos.Clear()
        ListaComentario.Clear()
    End Sub
    Public Sub Crearclase(listaToken As List(Of Token))
        Dim nombre As String = ""
        Dim color As String = ""
        Dim texto As String = ""
        Dim p, camino, llaveCl As Integer
        Dim visibilidad, variable, tipo As String
        Dim listaTempAtributos As New List(Of Atributos)
        Dim listaTempMetodos As New List(Of Metodos)
        Limpiar()
        If listaToken IsNot Nothing Then
            Dim x As Integer = listaToken.Count
            For i As Integer = 0 To x Step 1
                If i < x - 1 Then
                    Dim token1 As Token = listaToken(i)
                    Dim token2 As Token = listaToken(i + 1)
                    If token1.PToken = 1000 Then
                        camino = 1000
                    ElseIf token1.PToken = 5000 Then
                        camino = 5000
                    ElseIf token1.PToken = 11000 Then
                        camino = 11000
                    End If
                    If camino = 1000 Then
                        If token1.PToken = 2000 Then
                            p = 2000
                        ElseIf token1.PToken = 3000 Then
                            p = 3000
                        ElseIf token1.PToken = 4000 Then
                            p = 4000
                        ElseIf token1.PToken = 10000 Then
                            p = 10000
                        End If
                        If p = 2000 Then
                            If token1.Plexema = "=" Then
                                nombre = token2.Plexema
                            End If
                        ElseIf p = 4000 Then
                            If token1.PToken = 10 Or token1.PToken = 11 Or token1.PToken = 9 Then
                                Dim token3 As Token = listaToken(i + 3)
                                Dim tokenV As Token = listaToken(i + 2)
                                If token3.Plexema = ":" Then
                                    Dim token4 As Token = listaToken(i + 4)
                                    tipo = token4.Plexema
                                Else
                                    tipo = ""
                                End If
                                visibilidad = token1.Plexema
                                variable = tokenV.Plexema
                                listaTempAtributos.Add(New Atributos(visibilidad, variable, tipo, token1.PFila))
                                visibilidad = ""
                                tipo = ""
                                variable = ""
                            End If
                        ElseIf p = 3000 Then
                            If token1.PToken = 10 Or token1.PToken = 11 Or token1.PToken = 9 Then
                                Dim token3 As Token = listaToken(i + 3)
                                Dim tokenV As Token = listaToken(i + 2)
                                If token3.Plexema = ":" Then
                                    Dim token4 As Token = listaToken(i + 4)
                                    tipo = token4.Plexema
                                Else
                                    tipo = ""
                                End If
                                visibilidad = token1.Plexema
                                variable = tokenV.Plexema
                                'ListaMetodos.Add(New Metodos(Nombre, visibilidad, variable, tipo))
                                listaTempMetodos.Add(New Metodos(visibilidad, variable, tipo, token1.PFila))
                                visibilidad = ""
                                variable = ""
                                tipo = ""
                            End If
                        ElseIf p = 10000 Then
                            If token1.Plexema = "=" Then
                                color = token2.Plexema + listaToken(i + 2).Plexema + listaToken(i + 3).Plexema + listaToken(i + 4).Plexema + listaToken(i + 5).Plexema
                            End If
                        End If
                        If token2.Plexema = "{" Then
                            llaveCl += 1
                        ElseIf token2.Plexema = "}" Then
                            llaveCl -= 1
                        End If
                        If llaveCl = 0 Then
                            If listaTempMetodos IsNot Nothing Then
                                For Each m As Metodos In listaTempMetodos
                                    ListaMetodos.Add(New Metodos(nombre, m.dameVisibilidad, m.dameVariable, m.dameRetorno, m.dameFile))
                                Next
                                listaTempMetodos.Clear()
                            End If
                            If listaTempAtributos IsNot Nothing Then
                                For Each a As Atributos In listaTempAtributos
                                    ListaAtributos.Add(New Atributos(nombre, a.dameVisibilidad, a.dameVariable, a.dameRetorno, a.Fila1))
                                Next
                                listaTempAtributos.Clear()
                            End If
                            If nombre <> "" And color <> "" Then
                                ListaClases.Add(New Clase(nombre, color))
                                nombre = ""
                                color = ""
                            End If
                        End If
                    ElseIf camino = 11000 Then
                        If token1.PToken = 2000 Then
                            nombre = listaToken(i + 3).Plexema
                        ElseIf token1.PToken = 12000 Then
                            texto = listaToken(i + 4).Plexema
                        End If
                        If token2.Plexema = "{" Then
                            llaveCl += 1
                        ElseIf token2.Plexema = "}" Then
                            llaveCl -= 1
                        End If
                        If llaveCl = 0 Then
                            If nombre <> "" And texto <> "" Then
                                ListaComentario.Add(New Comentario(nombre, texto))
                                nombre = ""
                                texto = ""
                            End If
                        End If
                    ElseIf camino = 5000 Then
                        If token1.PToken = 9000 Or token1.PToken = 6000 Or token1.PToken = 7000 Or token1.PToken = 8000 Then
                            Relacion.Add(New Relacion(listaToken(i - 2).Plexema, listaToken(i + 2).Plexema, token1.Plexema))
                        ElseIf listaToken(i - 1).PToken = 200 And token1.PToken = 8 And token2.PToken = 200 Then
                            RelacionComen.Add(New Relacion(listaToken(i - 1).Plexema, token2.Plexema))
                        End If
                    End If
                End If
            Next
        End If
    End Sub
    Public Sub imprimirClases()
        Dim interfa As Boolean = True
        TextoRelacion = ""
        Dim tempClase As String = ""
        Dim tempAtributos As String = ""
        Dim tempMetodos As String = ""
        Dim tempAbstract As String = ""
        Dim tempColor As String = ""
        If ListaClases IsNot Nothing Then
            For Each Clase As Clase In ListaClases
                tempClase = Clase.DameNombre
                tempColor = toHex(Clase.DameColor)
                If ListaAtributos IsNot Nothing Then
                    For Each Atributos As Atributos In ListaAtributos
                        If Clase.DameNombre = Atributos.dameClase Then
                            interfa = False
                            tempAtributos += Atributos.dameVisibilidad & " " & Atributos.dameVariable & " " & Atributos.dameRetorno & "\n"
                        End If
                    Next
                End If
                If ListaMetodos IsNot Nothing Then
                    For Each Metodos As Metodos In ListaMetodos
                        If Clase.DameNombre = Metodos.dameClase Then
                            tempMetodos += Metodos.dameVisibilidad & " " & Metodos.dameVariable & "(" & Metodos.dameRetorno & ")" & "\n"
                        End If
                    Next
                End If
                If interfa Then
                    tempAbstract = "\<\<Interface\>\>"
                End If
                TextoRelacion += tempClase & "[label = ""{" & tempClase & "\n " & tempAbstract & "|" & tempAtributos & "|" & tempMetodos & "}"" fillcolor =""" & tempColor & " ""]"
                interfa = True
                tempClase = ""
                tempMetodos = ""
                tempAtributos = ""
                tempAbstract = ""
                tempColor = ""
            Next
        End If
        If ListaComentario IsNot Nothing Then
            For Each Comentario As Comentario In ListaComentario
                TextoRelacion += Comentario.dameNombre & "[label = ""{ " & Comentario.dameTexto & "} "" fillcolor=""#f2f221""]"
            Next
        End If
        If Relacion IsNot Nothing Then
            For Each rel As Relacion In Relacion
                If Existe(rel.dameClase1) And Existe(rel.dameClase2) Then
                    If rel.dameRelacion.ToString.ToLower = PR6.ToLower Then
                        TextoRelacion += rel.dameClase2 & "->" & rel.dameClase1 & "[arrowtail = ""onormal""]"
                    ElseIf rel.dameRelacion.ToString.ToLower = PR7.ToLower Then
                        TextoRelacion += rel.dameClase2 & "->" & rel.dameClase1 & "[arrowtail = odiamond]"
                    ElseIf rel.dameRelacion.ToString.ToLower = PR9.ToLower Then
                        TextoRelacion += rel.dameClase2 & "->" & rel.dameClase1 & "[arrowtail = ""none""]"
                    ElseIf rel.dameRelacion.ToString.ToLower = PR8.ToLower Then
                        TextoRelacion += rel.dameClase2 & "->" & rel.dameClase1 & "[arrowtail = ""diamond""]"
                    End If
                End If
            Next
        End If
        If RelacionComen IsNot Nothing Then
            For Each comen As Relacion In RelacionComen
                If ExisteComen(comen.dameClase1) And ExisteComen(comen.dameClase2) Then
                    TextoRelacion += comen.dameClase1 & "->" & comen.dameClase2 & "[style=dashed arrowtail = none]"
                End If
            Next
        End If
        CrearDot(TextoRelacion)
        GenerarImagen()
        TextoRelacion = ""
    End Sub
    Function toHex(s1 As String)
        Dim s2 As String = ""
        For Each s As String In s1.Split(",")
            s2 &= CInt(s).ToString("x2")
        Next s
        Return "#" & s2
    End Function
    Function Existe(nombre As String)
        Dim encontrado As Boolean = False
        If ListaClases IsNot Nothing Then
            Dim x As Integer = ListaClases.Count
            Dim i As Integer = 0
            While encontrado = False AndAlso i < x
                Dim xsda As String = ListaClases(i).DameNombre
                If nombre.Equals(xsda, StringComparison.OrdinalIgnoreCase) Then
                    encontrado = True
                End If
                i += 1
            End While
        End If
        If encontrado Then
            Return True
        Else
            Return False
        End If
    End Function
    Function ExisteComen(nombre As String)
        Dim encontrado As Boolean = False
        If ListaClases IsNot Nothing Then
            Dim x As Integer = ListaClases.Count
            Dim i As Integer = 0
            While encontrado = False AndAlso i < x
                Dim xsda As String = ListaClases(i).DameNombre
                If nombre.Equals(xsda, StringComparison.OrdinalIgnoreCase) Then
                    encontrado = True
                End If
                i += 1
            End While
        End If
        If ListaComentario IsNot Nothing Then
            Dim x As Integer = ListaComentario.Count
            Dim i As Integer = 0
            While encontrado = False AndAlso i < x
                Dim xsda As String = ListaComentario(i).dameNombre
                If nombre.Equals(xsda, StringComparison.OrdinalIgnoreCase) Then
                    encontrado = True
                End If
                i += 1
            End While
        End If
        If encontrado Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Function comprobarRepetidos(errores As List(Of Errores))
        MetodosRepetidos(errores)
        AtributosRepetidos(errores)
        Return errores
    End Function

    Public Sub MetodosRepetidos(errores As List(Of Errores))
        Dim tempMetodos As New List(Of Metodos)
        Dim x, y, z As Integer
        For i As Integer = 0 To ListaMetodos.Count - 1 Step 1
            Dim metodo As Metodos = ListaMetodos(i)
            tempMetodos.Add(metodo)
        Next
        For x = 0 To ListaMetodos.Count - 1
            z = 0
            For y = 0 To ListaMetodos.Count - 1
                If ListaMetodos(x).dameClase = tempMetodos(z).dameClase And y <> x And ListaMetodos(x).dameVariable.ToLower = tempMetodos(z).dameVariable.ToLower Then
                    errores.Add(New Errores("Metodo repetido", ListaMetodos(x).dameFile, 0, "Sintactico"))
                End If
                z = z + 1
            Next y
        Next x
    End Sub
    Public Sub AtributosRepetidos(errores As List(Of Errores))
        Dim tempAtributos As New List(Of Atributos)
        Dim x, y, z As Integer
        For i As Integer = 0 To ListaAtributos.Count - 1 Step 1
            Dim atributp As Atributos = ListaAtributos(i)
            tempAtributos.Add(atributp)
        Next
        For x = 0 To ListaAtributos.Count - 1
            z = 0
            For y = 0 To ListaAtributos.Count - 1
                If ListaAtributos(x).dameClase = tempAtributos(z).dameClase And y <> x And ListaAtributos(x).dameVariable = tempAtributos(z).dameVariable Then
                    errores.Add(New Errores("Atributo repetido", ListaAtributos(x).Fila1, 0, "Sintactico"))
                End If
                z = z + 1
            Next y
        Next x
    End Sub
End Class
