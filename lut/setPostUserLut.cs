// Custom Action by DumbGameDev
// www.dumbgamedev.com

using UnityEngine;
using UnityEngine.PostProcessing.Utilities;
using UnityEngine.PostProcessing;


namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("Post Processing Lut")]
	[Tooltip("Set User Lut Post Processing Effects.")]
	public class  setPostUserLut : FsmStateAction
	{

		[RequiredField]
		[CheckForComponent(typeof(PostProcessingController))]    
		public FsmOwnerDefault gameObject;

		public FsmTexture lut;
		public FsmFloat contribution;
		public FsmBool everyFrame;
		       
		UnityEngine.PostProcessing.Utilities.PostProcessingController behavior;

	public override void Reset()
		{
			contribution = null;
			lut = null;
			everyFrame = false;
		}
        
	
	public override void OnEnter()
		{

			var go = Fsm.GetOwnerDefaultTarget (gameObject);
			behavior = go.GetComponent<UnityEngine.PostProcessing.Utilities.PostProcessingController>();
			
			doPostProcess();
			
			if (!everyFrame.Value)
			{
				Finish();
			}
		}
			
		public override void OnUpdate()
		{
			if (everyFrame.Value)
			{
				doPostProcess();
			}
		}

		
		void doPostProcess()
		{
			
			behavior.userLut.lut = (Texture2D)lut.Value;
			behavior.userLut.contribution = contribution.Value;
			
		}
		
	}

}
