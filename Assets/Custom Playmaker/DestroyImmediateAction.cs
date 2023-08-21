using UnityEngine;
using HutongGames.PlayMaker;

namespace CustomPlaymaker // Replace with your actual namespace
{
    [ActionCategory(ActionCategory.ScriptControl)]
    [HutongGames.PlayMaker.Tooltip("Destroys a GameObject immediately.")]
    public class DestroyImmediateAction : FsmStateAction
    {
        [RequiredField]
        [HutongGames.PlayMaker.Tooltip("The GameObject to destroy.")]
        public FsmGameObject gameObject;

        public override void OnEnter()
        {
            if (gameObject.Value != null)
            {
                GameObject.DestroyImmediate(gameObject.Value);
            }

            Finish();
        }
    }
}
