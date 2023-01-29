<%@ Page Language="C#" MasterPageFile="~/MasterPages/FormDetail.master" AutoEventWireup="true" ValidateRequest="false" CodeFile="FM000003.aspx.cs" Inherits="Page_FM000003" Title="Untitled Page" %>
<%@ MasterType VirtualPath="~/MasterPages/FormDetail.master" %>

<asp:Content ID="cont1" ContentPlaceHolderID="phDS" Runat="Server">
	<px:PXDataSource ID="ds" runat="server" Visible="True" Width="100%"
        TypeName="RulesEngine.FileCategoryTransMaint"
        PrimaryView="MasterView"
        >
		<CallbackCommands>

		</CallbackCommands>
	</px:PXDataSource>
</asp:Content>
<asp:Content ID="cont2" ContentPlaceHolderID="phF" Runat="Server">
	<px:PXFormView ID="form" runat="server" DataSourceID="ds" DataMember="MasterView" Width="100%" Height="" AllowAutoHide="false">
		<Template>
			<px:PXLayoutRule runat="server" ID="CstPXLayoutRule3" StartColumn="True" ></px:PXLayoutRule>
			<px:PXTextEdit Size="200px" runat="server" ID="CstPXTextEdit4" DataField="NameFilter" ></px:PXTextEdit>
			<px:PXLayoutRule runat="server" ID="CstPXLayoutRule2" StartColumn="True" ></px:PXLayoutRule>
			<px:PXTextEdit Size="200px" runat="server" ID="CstPXTextEdit5" DataField="CategoryFilter" ></px:PXTextEdit>
			<px:PXLayoutRule runat="server" ID="CstPXLayoutRule1" StartColumn="True" ></px:PXLayoutRule>
			<px:PXTextEdit Size="200px" runat="server" ID="CstPXTextEdit6" DataField="SummaryFilter" ></px:PXTextEdit></Template>
	</px:PXFormView>
</asp:Content>
<asp:Content ID="cont3" ContentPlaceHolderID="phG" Runat="Server">
	<px:PXGrid ID="grid" runat="server" DataSourceID="ds" Width="100%" Height="150px" SkinID="Details" AllowAutoHide="false">
		<Levels>
			<px:PXGridLevel DataMember="DetailsView">
			    <Columns>
				<px:PXGridColumn DataField="Name" Width="600" ></px:PXGridColumn>
				<px:PXGridColumn DataField="Category" Width="140" ></px:PXGridColumn>
				<px:PXGridColumn DataField="Summary" Width="300" ></px:PXGridColumn></Columns>
			</px:PXGridLevel>
		</Levels>
		<AutoSize Container="Window" Enabled="True" MinHeight="150" ></AutoSize>
		<ActionBar >
		
			<Actions>
				<AddNew Enabled="False" ></AddNew>
						<Delete Enabled="False" /></Actions></ActionBar>
	</px:PXGrid>
</asp:Content>
