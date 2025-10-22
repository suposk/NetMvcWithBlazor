////net 5
//window.saveAsFile = function (fileName, byteBase64) {
//    var link = this.document.createElement('a');
//    link.download = fileName;
//    link.href = "data:application/octet-stream;base64," + byteBase64;
//    this.document.body.appendChild(link);
//    link.click();
//    this.document.body.removeChild(link);
//}

// Use it for .NET 6+
function saveAsFile(filename, content) {
    // Create the URL
    const file = new File([content], filename, { type: "application/octet-stream" });
    const exportUrl = URL.createObjectURL(file);

    // Create the <a> element and click on it
    const a = document.createElement("a");
    document.body.appendChild(a);
    a.href = exportUrl;
    a.download = filename;
    a.target = "_self";
    a.click();

    // We don't need to keep the object URL, let's release the memory
    // On older versions of Safari, it seems you need to comment this line...
    URL.revokeObjectURL(exportUrl);
}

window.getWindowDimensions = function () {
    return {
        width: window.innerWidth,
        height: window.innerHeight
    };
}; 