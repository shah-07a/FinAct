
Module MdlCustMze
    Public Sub xCustMize()
        Try
            FrmMainMdi.PURCHASEBILLINGWITHOUTINVENTORYToolStripMenuItem.Visible = True
            FrmMainMdi.OUTSOURCINGINWARDSToolStripMenuItem.Visible = False
            FrmMainMdi.SALEBILLINGWITHOUTINVENTRYToolStripMenuItem.Visible = True
            FrmMainMdi.MATERIALMOVEMENTToolStripMenuItem.Visible = False
            FrmMainMdi.WORKORDERToolStripMenuItem.Visible = False
            FrmMainMdi.HRPAYROLLToolStripMenuItem.Visible = False
            Select Case True
                Case Cl_Kbl

                Case Cl_Ltg
                    FrmMainMdi.ToolStripMenuItem20.Enabled = False
                    FrmMainMdi.ToolStripMenuItem18.Enabled = False
                    FrmMainMdi.ToolStripMenuItem20.Visible = False
                    FrmMainMdi.ToolStripMenuItem18.Visible = False
                Case Cl_TimeIndia
                    FrmMainMdi.OUTSOURCINGINWARDSToolStripMenuItem.Visible = True
                    FrmMainMdi.MATERIALMOVEMENTToolStripMenuItem.Visible = True
                    FrmMainMdi.WORKORDERToolStripMenuItem.Visible = True
                    FrmMainMdi.HRPAYROLLToolStripMenuItem.Visible = True
                Case Cl_TimeRubber
                Case Else
            End Select
        Catch ex As Exception

        End Try
    End Sub

End Module
