// Custom Action by DumbGameDev
// www.dumbgamedev.com

using UnityEngine;
using UnityEngine.PostProcessing.Utilities;
using UnityEngine.PostProcessing;


namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("Post Processing Channel Mixer")]
	[Tooltip("Set Channel Mixer Color Grading Post Processing Effects Red.")]
	public class setPostColorGraderChannelMixerRed : FsmStateAction
	{

		[RequiredField]
		[CheckForComponent(typeof(PostProcessingController))]    
		public FsmOwnerDefault gameObject;

		public FsmVector3 red;
		public FsmBool everyFrame;

		UnityEngine.PostProcessing.Utilities.PostProcessingController behavior;

	
		public override void Reset()
		{
			red = null;
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

			behavior.colorGrading.channelMixer.red = red.Value;

		}

	}
}