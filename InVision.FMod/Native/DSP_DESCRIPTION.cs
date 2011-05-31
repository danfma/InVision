using System;
using System.Runtime.InteropServices;

namespace InVision.FMod.Native
{
	public struct DSP_DESCRIPTION
	{
		[MarshalAs(UnmanagedType.ByValArray,SizeConst=32)]
		public char[]                      name;               /* [in] Name of the unit to be displayed in the network. */
		public uint                        version;            /* [in] Plugin writer's version number. */
		public int                         channels;           /* [in] Number of channels.  Use 0 to process whatever number of channels is currently in the network.  >0 would be mostly used if the unit is a unit that only generates sound. */
		public DSP_CREATECALLBACK          create;             /* [in] Create callback.  This is called when DSP unit is created.  Can be null. */
		public DSP_RELEASECALLBACK         release;            /* [in] Release callback.  This is called just before the unit is freed so the user can do any cleanup needed for the unit.  Can be null. */
		public DSP_RESETCALLBACK           reset;              /* [in] Reset callback.  This is called by the user to reset any history buffers that may need resetting for a filter, when it is to be used or re-used for the first time to its initial clean state.  Use to avoid clicks or artifacts. */
		public DSP_READCALLBACK            read;               /* [in] Read callback.  Processing is done here.  Can be null. */
		public DSP_SETPOSITIONCALLBACK     setposition;        /* [in] Setposition callback.  This is called if the unit wants to update its position info but not process data.  Can be null. */

		public int                         numparameters;      /* [in] Number of parameters used in this filter.  The user finds this with DSP::getNumParameters */
		public DSP_PARAMETERDESC[]         paramdesc;          /* [in] Variable number of parameter structures. */
		public DSP_SETPARAMCALLBACK        setparameter;       /* [in] This is called when the user calls DSP::setParameter.  Can be null. */
		public DSP_GETPARAMCALLBACK        getparameter;       /* [in] This is called when the user calls DSP::getParameter.  Can be null. */
		public DSP_DIALOGCALLBACK          config;             /* [in] This is called when the user calls DSP::showConfigDialog.  Can be used to display a dialog to configure the filter.  Can be null. */
		public int                         configwidth;        /* [in] Width of config dialog graphic if there is one.  0 otherwise.*/
		public int                         configheight;       /* [in] Height of config dialog graphic if there is one.  0 otherwise.*/
		public IntPtr                      userdata;           /* [in] Optional. Specify 0 to ignore. This is user data to be attached to the DSP unit during creation.  Access via DSP::getUserData. */
	}
}