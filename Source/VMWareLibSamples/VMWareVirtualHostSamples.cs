﻿using System;
using System.Collections.Generic;
using System.Text;
using Vestris.VMWareLib;
using NUnit.Framework;

namespace Vestris.VMWareLibSamples
{
    [TestFixture]
    public class VMWareVirtualHostSamples
    {
        [Test]
        public void GettingStartedWorkstation()
        {
            #region Example: Getting Started (Workstation)
            // declare a virtual host
            using (VMWareVirtualHost virtualHost = new VMWareVirtualHost())
            {
                // connect to a local VMWare Workstation virtual host
                virtualHost.ConnectToVMWareWorkstation();
                // open an existing virtual machine
                using (VMWareVirtualMachine virtualMachine = virtualHost.Open(@"C:\Virtual Machines\xp\xp.vmx"))
                {
                    // power on this virtual machine
                    virtualMachine.PowerOn();
                    // wait for VMWare Tools
                    virtualMachine.WaitForToolsInGuest();
                    // login to the virtual machine
                    virtualMachine.LoginInGuest("Administrator", "password");
                    // run notepad
                    virtualMachine.RunProgramInGuest("notepad.exe", string.Empty);
                    // create a new snapshot
                    string name = "New Snapshot";
                    // take a snapshot at the current state
                    VMWareSnapshot createdSnapshot = virtualMachine.Snapshots.CreateSnapshot(name, "test snapshot");
                    createdSnapshot.Dispose();
                    // power off
                    virtualMachine.PowerOff();
                    // find the newly created snapshot
                    using (VMWareSnapshot foundSnapshot = virtualMachine.Snapshots.GetNamedSnapshot(name))
                    {
                        // revert to the new snapshot
                        foundSnapshot.RevertToSnapshot();
                        // delete snapshot
                        foundSnapshot.RemoveSnapshot();
                    }
                }
            }
            #endregion
        }

        [Test]
        public void GettingStartedServer2x()
        {
            #region Example: Getting Started (Server 2.x)
            // declare a virtual host
            using (VMWareVirtualHost virtualHost = new VMWareVirtualHost())
            {
                // connect to a local VMWare Server 2.x virtual host
                virtualHost.ConnectToVMWareVIServer("localhost:8333", "vmuser", "password");
                // open an existing virtual machine
                using (VMWareVirtualMachine virtualMachine = virtualHost.Open(@"[standard] xp/xp.vmx"))
                {
                    // power on this virtual machine
                    virtualMachine.PowerOn();
                    // wait for VMWare Tools
                    virtualMachine.WaitForToolsInGuest();
                    // login to the virtual machine
                    virtualMachine.LoginInGuest("Administrator", "password");
                    // run notepad
                    virtualMachine.RunProgramInGuest("notepad.exe", string.Empty);
                    // create a new snapshot
                    string name = "New Snapshot";
                    // take a snapshot at the current state
                    virtualMachine.Snapshots.CreateSnapshot(name, "test snapshot");
                    // power off
                    virtualMachine.PowerOff();
                    // find the newly created snapshot
                    using (VMWareSnapshot snapshot = virtualMachine.Snapshots.GetNamedSnapshot(name))
                    {
                        // revert to the new snapshot
                        snapshot.RevertToSnapshot();
                        // delete snapshot
                        snapshot.RemoveSnapshot();
                    }
                }
            }
            #endregion
        }

        [Test]
        public void GettingStartedVI()
        {
            #region Example: Getting Started (VI)
            // declare a virtual host
            using (VMWareVirtualHost virtualHost = new VMWareVirtualHost())
            {
                // connect to a remove (VMWare ESX) virtual machine
                virtualHost.ConnectToVMWareVIServer("esx.mycompany.com", "vmuser", "password");
                // open an existing virtual machine
                using (VMWareVirtualMachine virtualMachine = virtualHost.Open("[storage] testvm/testvm.vmx"))
                {
                    // power on this virtual machine
                    virtualMachine.PowerOn();
                    // wait for VMWare Tools
                    virtualMachine.WaitForToolsInGuest();
                    // login to the virtual machine
                    virtualMachine.LoginInGuest("Administrator", "password");
                    // run notepad
                    virtualMachine.RunProgramInGuest("notepad.exe", string.Empty);
                    // create a new snapshot
                    string name = "New Snapshot";
                    // take a snapshot at the current state
                    virtualMachine.Snapshots.CreateSnapshot(name, "test snapshot");
                    // power off
                    virtualMachine.PowerOff();
                    // find the newly created snapshot
                    using (VMWareSnapshot snapshot = virtualMachine.Snapshots.GetNamedSnapshot(name))
                    {
                        // revert to the new snapshot
                        snapshot.RevertToSnapshot();
                        // delete snapshot
                        snapshot.RemoveSnapshot();
                    }
                }
            }
            #endregion
        }
    }
}
