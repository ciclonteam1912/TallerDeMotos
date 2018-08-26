function UseMutationObserver() {
    /* Bind Mutation Events */
    var elements = $("#contenido").find("[data-role=combobox],[data-role=dropdownlist],[data-role=numerictextbox],[data-role^=date],[data-role=multiselect]");

    //correct mutation event detection
    var hasMutationEvents = ("MutationEvent" in window),
        MutationObserver = window.WebKitMutationObserver || window.MutationObserver;

    if (MutationObserver) {
        var observer = new MutationObserver(function (mutations) {
            var idx = 0,
                mutation,
                length = mutations.length;

            for (; idx < length; idx++) {
                mutation = mutations[idx];
                if (mutation.attributeName === "class") {
                    updateCssOnPropertyChange(mutation);
                }
            }
        }),
        config = { attributes: true, childList: false, characterData: false };

        elements.each(function () {
            observer.observe(this, config);
        });
    } else if (hasMutationEvents) {
        elements.bind("DOMAttrModified", updateCssOnPropertyChange);
    } else {
        elements.each(function () {
            this.attachEvent("onpropertychange", updateCssOnPropertyChange);
        });        
    }
}