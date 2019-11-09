﻿var fs = require('fs');
var yaml = require('js-yaml');
var toc = yaml.safeLoad(fs.readFileSync('./api/toc.yml'));

var namespaces = {};

for(var i=0; i<toc.length; i++) {
    var fullnamespace = toc[i].uid;
    var splitnamespace = fullnamespace.split('.');

    var parent = namespaces;

    for(var j = 0; j < splitnamespace.length; j++) {
        var partialnamespace = splitnamespace[j];

        if(parent[partialnamespace] == undefined) {
            parent[partialnamespace] = {};
        }
        parent = parent[partialnamespace];
    }

    if(parent.items == undefined) {
        parent.items = toc[i].items;
    }
    else {
        parent.items.push(toc[i]);
    }
}

var newToc = [];

function recurse(obj, path="") {
    var items = [];
    Object.keys(obj).forEach((e, i)=>{
        if(e!="items") {
        var newPath;
        if(path=="") {
            newPath = e;
        }
        else {
            newPath = path + '.' + e;
        }
        var newObj = {uid: newPath, name: newPath, items: obj[e].items || []}
        newObj.items.push(...recurse(obj[e], newPath));
        items.push(newObj);
    }
});
    return items;
}

var items = recurse(namespaces);

fs.writeFileSync('./api/toc.yml', yaml.safeDump(items));