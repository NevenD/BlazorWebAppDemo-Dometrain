window.callreferencenetfromjs = (dotNetHelper) => {
    console.log();
    return dotNetHelper.invokeMethodAsync('GetHelloMessage');
};