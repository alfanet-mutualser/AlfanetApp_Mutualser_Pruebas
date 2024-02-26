<%@ Page Language="C#" MasterPageFile="~/MainMaster.master" AutoEventWireup="true"  CodeFile="MaePerfil.aspx.cs" Inherits="_Default" %>

<%@ Register Assembly="Infragistics2.WebUI.UltraWebNavigator.v7.1, Version=7.1.20071.40, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.WebUI.UltraWebNavigator" TagPrefix="ignav" %>

<%@ Register Assembly="Infragistics2.WebUI.UltraWebListbar.v7.1, Version=7.1.20071.40, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.WebUI.UltraWebListbar" TagPrefix="iglbar" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <span style="font-size: 24pt"><strong>
        <br />
    </strong></span>
    <br />
    <br />
    PAGINA PRINCIPAL DE PERFILES<br />
    <ignav:UltraWebTree ID="UltraWebTree1" runat="server" DefaultImage="" Height="190px"
        HiliteClass="" HoverClass="" Indentation="20" Width="197px">
        <Nodes>
            <ignav:Node Text="Nodo 1">
                <Nodes>
                    <ignav:Node Text="Nodo 1.1">
                        <Nodes>
                            <ignav:Node Text="Nodo 1.1.1">
                                <Nodes>
                                    <ignav:Node Text="Nodo 1.1.1.1">
                                    </ignav:Node>
                                    <ignav:Node Text="Nodo 1.1.1.2">
                                        <Nodes>
                                            <ignav:Node Text="Nodo 1.1.1.2.1">
                                            </ignav:Node>
                                        </Nodes>
                                    </ignav:Node>
                                </Nodes>
                            </ignav:Node>
                            <ignav:Node Text="Nodo 1.1.2">
                            </ignav:Node>
                            <ignav:Node Text="Nodo 1.1.3">
                            </ignav:Node>
                        </Nodes>
                    </ignav:Node>
                    <ignav:Node Text="Nodo 1.2">
                    </ignav:Node>
                </Nodes>
            </ignav:Node>
        </Nodes>
        <Levels>
            <ignav:Level Index="0" />
            <ignav:Level Index="1" />
            <ignav:Level Index="2" />
            <ignav:Level Index="3" />
            <ignav:Level Index="4" />
        </Levels>
    </ignav:UltraWebTree>
           
</asp:Content>

