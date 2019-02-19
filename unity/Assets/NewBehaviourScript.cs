﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


using SKM.V3;
using SKM.V3.Methods;
using SKM.V3.Models;


public class NewBehaviourScript : MonoBehaviour
{

    public Light myLight;

    //// Start is called before the first frame update
    private void Start()
    {
        var licenseKey = "GEBNC-WZZJD-VJIHG-GCMVD";
        var RSAPubKey = "<RSAKeyValue><Modulus>sGbvxwdlDbqFXOMlVUnAF5ew0t0WpPW7rFpI5jHQOFkht/326dvh7t74RYeMpjy357NljouhpTLA3a6idnn4j6c3jmPWBkjZndGsPL4Bqm+fwE48nKpGPjkj4q/yzT4tHXBTyvaBjA8bVoCTnu+LiC4XEaLZRThGzIn5KQXKCigg6tQRy0GXE13XYFVz/x1mjFbT9/7dS8p85n8BuwlY5JvuBIQkKhuCNFfrUxBWyu87CFnXWjIupCD2VO/GbxaCvzrRjLZjAngLCMtZbYBALksqGPgTUN7ZM24XbPWyLtKPaXF2i4XRR9u6eTj5BfnLbKAU5PIVfjIS+vNYYogteQ==</Modulus><Exponent>AQAB</Exponent></RSAKeyValue>";

        var auth = "WyIyNjg4IiwiN3dVZjVwM2svRU5nNkhEZnpSYWdWZ3R4OUQ5R2ZFVExwbEJMNFZyMCJd";
        var result = Key.Activate(token: auth, parameters: new ActivateModel()
        {
            Key = licenseKey,
            ProductId = 3349,
            Sign = true,
            MachineCode = Helpers.GetMachineCode()
        });

        if (result == null || result.Result == ResultType.Error ||
            !result.LicenseKey.HasValidSignature(RSAPubKey).IsOnRightMachine().IsValid())
        {
            // an error occurred or the key is invalid or it cannot be activated
            // (eg. the limit of activated devices was achieved)
            Debug.Log(result?.Message);
            Debug.Log(result?.LicenseKey.HasValidSignature(RSAPubKey).IsValid());
            Debug.Log("The license does not work.");
        }
        else
        {
            // everything went fine if we are here!
            Debug.Log("The license is valid!");
        }
    }

    //// Update is called once per frame
    //void Update()
    //{
    //    if (Input.GetKey("space"))
    //    {
    //        myLight.enabled = true;

    //        var licenseKey = "GEBNC-WZZJD-VJIHG-GCMVD";
    //        var RSAPubKey = "<RSAKeyValue><Modulus>sGbvxwdlDbqFXOMlVUnAF5ew0t0WpPW7rFpI5jHQOFkht/326dvh7t74RYeMpjy357NljouhpTLA3a6idnn4j6c3jmPWBkjZndGsPL4Bqm+fwE48nKpGPjkj4q/yzT4tHXBTyvaBjA8bVoCTnu+LiC4XEaLZRThGzIn5KQXKCigg6tQRy0GXE13XYFVz/x1mjFbT9/7dS8p85n8BuwlY5JvuBIQkKhuCNFfrUxBWyu87CFnXWjIupCD2VO/GbxaCvzrRjLZjAngLCMtZbYBALksqGPgTUN7ZM24XbPWyLtKPaXF2i4XRR9u6eTj5BfnLbKAU5PIVfjIS+vNYYogteQ==</Modulus><Exponent>AQAB</Exponent></RSAKeyValue>";

    //        var auth = "WyIyNjg4IiwiN3dVZjVwM2svRU5nNkhEZnpSYWdWZ3R4OUQ5R2ZFVExwbEJMNFZyMCJd";
    //        var result = Key.Activate(token: auth, parameters: new ActivateModel()
    //        {
    //            Key = licenseKey,
    //            ProductId = 3349,
    //            Sign = true,
    //            MachineCode = "test"
    //        });

    //        if (result == null || result.Result == ResultType.Error ||
    //            !result.LicenseKey.HasValidSignature(RSAPubKey).IsValid())
    //        {
    //            // an error occurred or the key is invalid or it cannot be activated
    //            // (eg. the limit of activated devices was achieved)
    //            Debug.Log("The license does not work.");
    //        }
    //        else
    //        {
    //            // everything went fine if we are here!
    //            Debug.Log("The license is valid!");
    //        }


    //    }
    //    else
    //    {
    //        myLight.enabled = false;
    //    }
    //}
}
