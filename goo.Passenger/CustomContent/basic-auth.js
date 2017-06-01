(function () {
    $(function () {
        $("#input_apiKey").hide();
        var authInputsLength = $('[id=input_auth]').length;
        if (authInputsLength==0) {
            var bearerAuthUI =
        '<div text="Access Token" class="input"><input placeholder="authraization token" id="input_auth" name="auth" type="text" size="10"></div>';
            $(bearerAuthUI).insertBefore('#api_selector div.input:last-child');
            $('#input_auth').change(addAuthorization);
        }
    
    });
    function addAuthorization() {
        var token = $('#input_auth').val();
        if (token && token.trim() != "" ) {
            var apiKeyAuth = new SwaggerClient.ApiKeyAuthorization("Authorization", "Bearer " + token, "header");
            window.swaggerUi.api.clientAuthorizations.add("bearer", apiKeyAuth);
            console.log("authorization added: token" + "Bearer " + token);
        }
    }
})();