/*using UnityEngine.Purchasing;
using UnityEngine;

public class OnPurchaseExecute : Execute, IIAPListener
{
    public bool consumePurchase = true;
    public IGet<string> productId;

    public string ID => productId.Get;

    public void Purchase()
    {
        Debug.LogWarning("Not implemented", this);
        //IAP.BuyProduct(ID);
    }

    void OnEnable()
    {
        Debug.LogWarning("Not implemented", this);
        //IAP.AddListener(this);
    }

    void OnDisable()
    {
        Debug.LogWarning("Not implemented", this);
        //IAP.RemoveListener(this);
    }


    PurchaseProcessingResult IIAPListener.Action()
    {
        base.Action();
        return consumePurchase ? PurchaseProcessingResult.Complete : PurchaseProcessingResult.Pending;
    }
}*/
