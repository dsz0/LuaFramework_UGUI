﻿using UnityEngine;
using System.Collections;
using LuaFramework;

using Consolation;
public class StartUpCommand : ControllerCommand
{
    public override void Execute(IMessage message)
    {
        if (!Util.CheckEnvironment()) return;

        GameObject gameMgr = GameObject.Find("GameManager");
        if (gameMgr != null)
        {
            //AppView appView = 
            gameMgr.AddComponent<AppView>();
            //TestConsole console = 
            gameMgr.AddComponent<TestConsole>();
        }
        //-----------------关联命令-----------------------
        AppFacade.Instance.RegisterCommand(NotiConst.DISPATCH_MESSAGE, typeof(SocketCommand));

        //-----------------初始化管理器-----------------------
        AppFacade.Instance.AddManager<LuaManager>(ManagerName.Lua);
        AppFacade.Instance.AddManager<PanelManager>(ManagerName.Panel);
        AppFacade.Instance.AddManager<SoundManager>(ManagerName.Sound);
        AppFacade.Instance.AddManager<TimerManager>(ManagerName.Timer);
        AppFacade.Instance.AddManager<NetworkManager>(ManagerName.Network);
        AppFacade.Instance.AddManager<RazNetworkManager>(ManagerName.RazNetwork);
        AppFacade.Instance.AddManager<LuaResourceManager>(ManagerName.Resource);
        AppFacade.Instance.AddManager<ThreadManager>(ManagerName.Thread);
        AppFacade.Instance.AddManager<ObjectPoolManager>(ManagerName.ObjectPool);
        AppFacade.Instance.AddManager<HotFixManager>(ManagerName.MainLua);
    }
}