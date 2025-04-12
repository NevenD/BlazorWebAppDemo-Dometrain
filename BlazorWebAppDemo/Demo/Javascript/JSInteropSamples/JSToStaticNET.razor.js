
window.callnetfromjs = () => {
    DotNet.invokeMethodAsync('BlazorWebAppDemo', 'NameOfTheMethod')
        .then(data => {
            alert(data);
        });
};
