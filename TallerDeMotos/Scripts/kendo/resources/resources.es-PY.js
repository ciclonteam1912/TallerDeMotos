﻿(function (trv, $) {
    "use strict";
    var sr = {
        //warning and error string resources
        controllerNotInitialized: 'Controller is not initialized.',
        noReportInstance: 'No report instance.',
        missingTemplate: '!obsolete resource!',
        noReport: 'No report.',
        noReportDocument: 'No report document.',
        missingOrInvalidParameter: 'Missing or invalid parameter value. Please input valid data for all parameters.',
        invalidParameter: 'Please input a valid value.',
        invalidDateTimeValue: 'Please input a valid date.',
        parameterIsEmpty: 'Parameter value cannot be empty.',
        cannotValidateType: 'Cannot validate parameter of type {type}.',
        loadingFormats: 'Loading...',
        loadingReport: 'Loading report...',
        preparingDownload: 'Preparing document to download. Please wait...',
        preparingPrint: 'Preparing document to print. Please wait...',
        errorLoadingTemplates: 'Error loading the report viewer\'s templates. (Template = {0}).',
        loadingReportPagesInProgress: '{0} pages loaded so far...',
        loadedReportPagesComplete: 'Done. Total {0} pages loaded.',
        noPageToDisplay: "No page to display.",
        errorDeletingReportInstance : 'Error deleting report instance: {0}.', 
        errorRegisteringViewer : 'Error registering the viewer with the service.', 
        noServiceClient : 'No serviceClient has been specified for this controller.', 
        errorRegisteringClientInstance : 'Error registering client instance.', 
        errorCreatingReportInstance : 'Error creating report instance (Report = {0}).', 
        errorCreatingReportDocument : 'Error creating report document (Report = {0}; Format = {1}).', 
        unableToGetReportParameters: 'Unable to get report parameters.',
        errorObtainingAuthenticationToken: 'Error obtaining authentication token.',
        clientExpired: "Click 'Refresh' to restore client session.",

        //viewer template string resources
        parameterEditorSelectNone: 'Limpiar Selección',
        parameterEditorSelectAll: 'select all',
        parametersAreaPreviewButton: 'Preview',

        menuNavigateBackwardText: 'Navigate Backward',
        menuNavigateBackwardTitle: 'Navigate Backward',
        menuNavigateForwardText: 'Navigate Forward',
        menuNavigateForwardTitle: 'Navigate Forward',
        menuRefreshText: 'Refresh',
        menuRefreshTitle: 'Refresh',
        menuFirstPageText: 'First Page',
        menuFirstPageTitle: 'First Page',
        menuLastPageText: 'Last Page',
        menuLastPageTitle: 'Last Page',
        menuPreviousPageTitle: 'Previous Page',
        menuNextPageTitle: 'Next Page',
        menuPageNumberTitle: 'Page Number Selector',
        menuDocumentMapTitle: 'Toggle Document Map',
        menuParametersAreaTitle: 'Toggle Parameters Area',
        menuZoomInTitle: 'Zoom In',
        menuZoomOutTitle: 'Zoom Out',
        menuPageStateTitle: 'Toggle FullPage/PageWidth',
        menuPrintText: 'Print...',
        menuPrintTitle: 'Print',
        menuExportText: 'Export',
        menuExportTitle: 'Export',
        menuPrintPreviewText: 'Toggle Print Preview',
        menuPrintPreviewTitle: 'Toggle Print Preview',
        menuSearchText: 'Search',
        menuSearchTitle: 'Toggle Search',
        menuSideMenuTitle: 'Toggle Side Menu',

        //accessibility string resources
        ariaLabelPageNumberSelector: "Page number selector. Showing page {0} of {1}.",
        ariaLabelPageNumberEditor: "Page number editor",
        ariaLabelExpandable: "Expandable",
        ariaLabelSelected: "Selected",
        ariaLabelParameter: "parameter",
        ariaLabelErrorMessage: "Error message",
        ariaLabelParameterInfo: "Contains {0} options",
        ariaLabelMultiSelect: "Multiselect",
        ariaLabelMultiValue: "Multivalue",
        ariaLabelSingleValue: "Single value",
        ariaLabelParameterDateTime: "DateTime",
        ariaLabelParameterString: "String",
        ariaLabelParameterNumerical: "Numerical",
        ariaLabelParameterBoolean: "Boolean",
        ariaLabelParametersAreaPreviewButton: 'Preview the report',
        ariaLabelMainMenu: 'Main menu',
        ariaLabelCompactMenu: 'Compact menu',
        ariaLabelSideMenu: 'Side menu',
        ariaLabelDocumentMap: 'Document map area',
        ariaLabelPagesArea: 'Report contents area',
        ariaLabelSearchDialogArea: 'Search area',
        ariaLabelSearchDialogStop: 'Stop search',
        ariaLabelSearchDialogOptions: 'Search options',
        ariaLabelSearchDialogNavigateUp: 'Navigate up',
        ariaLabelSearchDialogNavigateDown: 'Navigate down',
        ariaLabelSearchDialogMatchCase: 'Match case',
        ariaLabelSearchDialogMatchWholeWord: 'Match whole word',
        ariaLabelSearchDialogUseRegex: 'Use regex',
        ariaLabelMenuNavigateBackward: 'Navigate backward',
        ariaLabelMenuNavigateForward: 'Navigate forward',
        ariaLabelMenuRefresh: 'Refresh',
        ariaLabelMenuFirstPage: 'First page',
        ariaLabelMenuLastPage: 'Last page',
        ariaLabelMenuPreviousPage: 'Previous page',
        ariaLabelMenuNextPage: 'Next page',
        ariaLabelMenuPageNumber: 'Page number selector',
        ariaLabelMenuDocumentMap: 'Toggle document map',
        ariaLabelMenuParametersArea: 'Toggle parameters area',
        ariaLabelMenuZoomIn: 'Zoom in',
        ariaLabelMenuZoomOut: 'Zoom out',
        ariaLabelMenuPageState: 'Toggle FullPage/PageWidth',
        ariaLabelMenuPrint: 'Print',
        ariaLabelMenuExport: 'Export',
        ariaLabelMenuPrintPreview: 'Toggle print preview',
        ariaLabelMenuSearch: 'Search in report contents',
        ariaLabelMenuSideMenu: 'Toggle side menu',

        //search dialog resources
        searchDialogTitle: 'Search in report contents',
        searchDialogSearchInProgress: "searching...",
        searchDialogNoResultsLabel: "No results",
        searchDialogResultsFormatLabel: "Result {0} of {1}",
        searchDialogStopTitle: 'Stop Search',
        searchDialogNavigateUpTitle: 'Navigate Up',
        searchDialogNavigateDownTitle: 'Navigate Down',
        searchDialogMatchCaseTitle: 'Match Case',
        searchDialogMatchWholeWordTitle: 'Match Whole Word',
        searchDialogUseRegexTitle: 'Use Regex',
        searchDialogCaptionText: 'Find',
    };
    trv.sr = $.extend(trv.sr, sr);
}(window.telerikReportViewer = window.telerikReportViewer || {}, jQuery));