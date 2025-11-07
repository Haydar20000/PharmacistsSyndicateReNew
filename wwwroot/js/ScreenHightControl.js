function load() {
    var offsetFooter = document.getElementById('theFooter').offsetHeight;
    var offsetHeader = document.getElementById('theHeader').offsetHeight;
    var fullHeight = Math.max(document.body.scrollHeight, document.body.offsetHeight, document.documentElement.clientHeight, document.documentElement.scrollHeight, document.documentElement.offsetHeight);
    var bodyHeight = fullHeight - (offsetFooter + offsetHeader) - 70;
    document.getElementById("theBody").style.minHeight = bodyHeight + "px";
};