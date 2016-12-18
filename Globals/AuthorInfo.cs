/**************************************************************************************************
 * 描述：
 *      在此定义项目作者的信息。
 * 
 * 
 **************************************************************************************************/

using System;
using System.Reflection;
using System.Resources;

[assembly: AssemblyCompany("Wlitsoft")]
[assembly: AssemblyCopyright("Copyright Wlitsoft 2012 - 2016")]
[assembly: AssemblyTrademark("Copyright © Copyright")]
[assembly: AssemblyProduct("Wlitsoft 框架")]

#if DEBUG
	[assembly: AssemblyConfiguration("DEBUG")]
#else
	[assembly: AssemblyConfiguration("RELEASE")]
#endif

[assembly: CLSCompliant(true)]
[assembly: NeutralResourcesLanguage("zh-CN")]