var BlazorUniversity = BlazorUniversity || {};
let data;


BlazorUniversity.setDataJsObjectFromXml = function (xmlText) {
    try
    {
        data = {};
        data = xml2js(xmlText, { compact: true, alwaysArray: true });
        return data;
    }
    catch { return null;}
};

BlazorUniversity.updateCustomer = function (refXml, name, code) {
    if (data["Profile"][0]["Customer"]) {
        data["Profile"][0]["Customer"][0]._attributes.name = name;
        data["Profile"][0]["Customer"][0]._attributes.code = code;
        var profileXml = json2xml(angular.toJson(data), {
            compact: true,
            spaces: 4,
            alwaysArray: true
        });
        refXml.innerText = profileXml
    }
}

//    profileModel.prototype.setData = function (data) {

//        this.data = xml2js(data, { compact: true, alwaysArray: true });
//    };

BlazorUniversity.clearDataJsObject = function () {
    data = null;
};

BlazorUniversity.getXml = function () {
    try {
        //this.data = xml2js(xmlText, { compact: true, alwaysArray: true });
        //alert(`profileModelXml2Xml() ok: ${this.data}`);
        var profileXml = json2xml(angular.toJson(data), {
            compact: true,
            spaces: 4,
            alwaysArray: true
        });
        //   alert(`dataJsObject2Xml() ok: ${profileXml}`);
        return profileXml
    } catch (e) {
        //alert(`dataJsObject2Xml() error: ${e.name}`);
    }
}

BlazorUniversity.dataJsObject2Xml = function (josnObject) {
    try {
        //this.data = xml2js(xmlText, { compact: true, alwaysArray: true });
        //alert(`profileModelXml2Xml() ok: ${this.data}`);
        var profileXml = json2xml(angular.toJson(josnObject), {
            compact: true,
            spaces: 4,
            alwaysArray: true
        });
     //   alert(`dataJsObject2Xml() ok: ${profileXml}`);
        return profileXml
    } catch (e) {
        //alert(`dataJsObject2Xml() error: ${e.name}`);
    }
}

BlazorUniversity.findInProfile0 = function (name) {
    if (data["Profile"][0][name]) {
        return data["Profile"][0][name][0];
    }
}

BlazorUniversity.findProfile = function () {
    if (data["Profile"]) {
        return data["Profile"][0];
    }
}

BlazorUniversity.findInInventoryProcessInformation0 = function (name) {
    if (data["Profile"][0]["InventoryProcessInformation"][0][name]) {
        return data["Profile"][0]["InventoryProcessInformation"][0][name][0];
    }
}


    BlazorUniversity.xml2json = function (xmlText) {
        try {
            alert(`BlazorUniversity.xml2json() in xmlText: ${xmlText}`);
            data1 = {};
            var data1 = xml2json(xmlText, { compact: true, alwaysArray: true });
            alert(`BlazorUniversity.xml2json() ok: ${data1}`);
            return data1;
        } catch (e) {
            alert(`BlazorUniversity.xml2json() error: ${e.name}`);
        }
    }

BlazorUniversity.xml2js = function (xmlText) {
    try {
        data2 = {};
        data2 = xml2js(xmlText, { compact: true, alwaysArray: true });
        alert(`BlazorUniversity.xml2js() ok: ${data2}`);
        return data2;
    } catch (e) {
        alert(`BlazorUniversity.xml2js() error: ${e.name}`);
    }
    }

BlazorUniversity.josn2xml = function (josnText) {
    try {
        var profileXml = json2xml(josnText, {
            compact: true,
            spaces: 4,
            alwaysArray: true
        });
        alert(`BlazorUniversity.josn2xml() ok: ${profileXml}`);
        return profileXml
    } catch (e) {
        alert(`BlazorUniversity.josn2xml() error: ${e.name}`);
    }
}

    //Work
    BlazorUniversity.profileModelJs2Xml = function (xmlText) {
        try {
            var data5 = xml2js(xmlText, { compact: true, alwaysArray: true });
            alert(`profileModelXml2Xml() ok: ${data5 }`);
            var profileXml = json2xml(angular.toJson(data5), {
                compact: true,
                spaces: 4,
                alwaysArray: true
            });
            alert(`profileModelXml2Xml() ok: ${profileXml}`);
            return profileXml
        } catch (e) {
            alert(`profileModelXml2Xml() error: ${e.name}`);
        }
    }



    //function profileModel($http, urlSettings) {

    //    var apiUrl = urlSettings.apiUrl;

    //    var profileModel = function () {

    //        this.data = {};
    //    };

    //    profileModel.prototype.setData = function (data) {

    //        this.data = xml2js(data, { compact: true, alwaysArray: true });
    //    };

    //    profileModel.prototype.find = function (name) {

    //        if (this.data["Profile"][0][name]) {
    //            return this.data["Profile"][0][name][0];
    //        }

    //    };

    //    profileModel.prototype.saveModel = function (organizationId) {

    //        var profileXml = json2xml(angular.toJson(this.data), {
    //            compact: true,
    //            spaces: 4,
    //            alwaysArray: true
    //        });

    //        return $http.post(apiUrl + '/organizations/' + organizationId + '/profile', {
    //            profileXml: profileXml
    //        });
    //    };

    //    profileModel.prototype.getData = function () {

    //        return this.data;
    //    };

    //    return {

    //        createEmpty: function () {
    //            return new profileModel();
    //        }
    //    }
    //}
