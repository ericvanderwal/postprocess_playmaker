// Custom Action by DumbGameDev
// www.dumbgamedev.com

using UnityEngine;
using UnityEngine.PostProcessing.Utilities;
using UnityEngine.PostProcessing;


namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("Post Processing Blur")]
	[Tooltip("Set Motion Blur Post Processing Effects Shutter Angle.")]
	public class  setPostMotionBlurShutterAngle : FsmStateAction
	{

		[RequiredField]
		[CheckForComponent(typeof(PostProcessingController))]    
		public FsmOwnerDefault gameObject;

		public FsmFloat shutterAngle;
		public FsmBool everyFrame;

		UnityEngine.PostProcessing.Utilities.PostProcessingController behavior;
	
		public override void Reset()
		{
			shutterAngle = null;
			everyFrame = null;
		}
        
		public override void OnEnter()
		{

			var go = Fsm.GetOwnerDefaultTarget(gameObject);
			behavior = go.GetComponent<UnityEngine.PostProcessing.Utilities.PostProcessingController>();

			if (!everyFrame.Value)
			{
				doPostProcess();
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

			var go = Fsm.GetOwnerDefaultTarget (gameObject);
			behavior = go.GetComponent<UnityEngine.PostProcessing.Utilities.PostProcessingController>();

			behavior.motionBlur.shutterAngle = shutterAngle.Value;

		}

	}
}