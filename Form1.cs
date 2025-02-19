using System;
using System.Threading;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;

namespace Fastboot_GUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Fastboot-GUI, By Leah.\n" +
                "A simple tool to read and write partitions on a device through \"fastboot\".", "Fastboot-GUI");

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ProcessStartInfo fastboot_cmd = new ProcessStartInfo();
            fastboot_cmd.FileName = "fastboot";
            fastboot_cmd.Arguments = "devices";
            fastboot_cmd.CreateNoWindow = true;
            fastboot_cmd.RedirectStandardOutput = true;
            fastboot_cmd.UseShellExecute = false;

            Process fastboot_prrocess = new Process();
            fastboot_prrocess.StartInfo = fastboot_cmd;
            fastboot_prrocess.Start();

            string output = fastboot_prrocess.StandardOutput.ReadToEnd();
            fastboot_prrocess.WaitForExit();

            string[] devices = output.Split('\n');

            Device_Selected.Items.Clear();
            foreach (string device in devices)
            {
                // First remove the word "fastboot",
                // remove all spaces,
                // Finally remove all newlines.
                //
                // This should work on 99% of devies
                // to get it's serial number / device
                // identifier in fastboot mode.
                string device_id = device.Replace("fastboot", "").Replace(" ","").Replace("\n","");
                if (!string.IsNullOrEmpty(device_id))
                {
                    Device_Selected.Items.Add(device_id.Trim());
                }
            }

            // Handle error to find devices
            if(devices.Length == 1) // 1 since there always is an entry that's empty for some reason.
            {
                if(MessageBox.Show(
                    "Failed to find devices, Is it plugged in and in FASTBOOT mode?",
                    "Fastboot-GUI",
                    MessageBoxButtons.RetryCancel,
                    MessageBoxIcon.Error
                ) == DialogResult.Retry)
                {
                    // weeeee recursion!
                    button1_Click(sender,e);
                    return;
                } else
                {
                    return;
                }
            }
            MessageBox.Show(
                "Successfully fetched devices!",
                "Fastboot-GUI",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void flash_selectFileButton_Click(object sender, EventArgs e)
        {

            openFileDialog1.Filter = "Image Files (*.img)|*.img|All Files (*.*)|*.*";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                flash_selectFileButton.Text = openFileDialog1.FileName;
            }
        }

        private void flash_btn_Click(object sender, EventArgs e)
        {
            ProcessStartInfo fastboot_cmd = new ProcessStartInfo();
            fastboot_cmd.FileName = "fastboot";
            fastboot_cmd.Arguments = "-s " + Device_Selected.SelectedItem + " flash " + partition_selected.SelectedItem + " " + flash_selectFileButton.Text;
            fastboot_cmd.CreateNoWindow = true;
            fastboot_cmd.RedirectStandardOutput = true;
            fastboot_cmd.UseShellExecute = false;

            Process fastboot_process = new Process();
            fastboot_process.StartInfo = fastboot_cmd;

            if(MessageBox.Show(
                    "Does this command look right? Please double check it before flashing.\n" + fastboot_cmd.FileName + " " + fastboot_cmd.Arguments,
                    "Fastboot-GUI",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                ) != DialogResult.Yes)
            {
                return;
            }

            fastboot_process.Start();
            string output = fastboot_process.StandardOutput.ReadToEnd();
            fastboot_process.WaitForExit();

            if (fastboot_process.ExitCode != 0)
            {
                if (
                    MessageBox.Show(
                        "Flashing " + partition_selected.SelectedItem + " failed.",
                        "Fastboot-GUI",
                        MessageBoxButtons.RetryCancel,
                        MessageBoxIcon.Warning
                        ) == DialogResult.Retry
                    )
                {
                    // weeeee
                    flash_btn_Click(sender, e);
                }
                else
                {
                    return;
                }
            }
            else
            {
                MessageBox.Show(
                    "Successfully flashed "+ flash_selectFileButton.Text + " to " + partition_selected.SelectedItem + ".",
                    "Fastboot-GUI",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
        }

        private void partition_refresh_Click(object sender, EventArgs e)
        {

            string device_id = Device_Selected.SelectedItem.ToString().Remove(Device_Selected.SelectedItem.ToString().Length-1, 1).Trim();

            // ProcessStartInfo fastboot_cmd = new ProcessStartInfo();
            // fastboot_cmd.FileName = "fastboot";
            // fastboot_cmd.Arguments = "getvar all";
            // fastboot_cmd.RedirectStandardOutput = true;
            // fastboot_cmd.RedirectStandardError = true;
            // fastboot_cmd.UseShellExecute = false;
            // 
            // Process fastboot_process = new Process();
            // fastboot_process.StartInfo = fastboot_cmd;
            // fastboot_process.Start();
            // fastboot_process.WaitForExit();
            // 
            // string output = fastboot_process.StandardOutput.ReadToEnd();
            // string error = fastboot_process.StandardError.ReadToEnd();

            // Hardcode output since my pc broken for some reason
            // This output is grabbed from a Google Pixel 7 pro, on AP5A.

            string output = @"(bootloader) ap-ar-ns:2
(bootloader) ap-ar-s:2
(bootloader) avb-hastree-error-mode:restart
(bootloader) battery-current:280 mA
(bootloader) battery-soc:68 %
(bootloader) battery-soc-ok:yes
(bootloader) battery-voltage:4055 mV
(bootloader) current-slot:a
(bootloader) ddr-manu:Micron
(bootloader) ddr-size:12GB
(bootloader) ddr-type:LPDDR5
(bootloader) enter-reason:reboot bootloader
(bootloader) erase-block-size:0x1000
(bootloader) fdevinit-count:0
(bootloader) fdevinit-set-time:0
(bootloader) fdevinit-total-time:0
(bootloader) fg-soc:65.64 %
(bootloader) gsa-fw-ar:2
(bootloader) has-slot:persist:no
(bootloader) has-slot:klog:no
(bootloader) has-slot:misc:no
(bootloader) has-slot:frp:no
(bootloader) has-slot:efs:no
(bootloader) has-slot:efs_backup:no
(bootloader) has-slot:modem_userdata:no
(bootloader) has-slot:metadata:no
(bootloader) has-slot:fips:no
(bootloader) has-slot:boot:yes
(bootloader) has-slot:init_boot:yes
(bootloader) has-slot:vendor_boot:yes
(bootloader) has-slot:vendor_kernel_boot:yes
(bootloader) has-slot:dtbo:yes
(bootloader) has-slot:vbmeta:yes
(bootloader) has-slot:vbmeta_system:yes
(bootloader) has-slot:vbmeta_vendor:yes
(bootloader) has-slot:pvmfw:yes
(bootloader) has-slot:modem:yes
(bootloader) has-slot:super:no
(bootloader) has-slot:userdata:no
(bootloader) has-slot:bl1:yes
(bootloader) has-slot:pbl:yes
(bootloader) has-slot:bl2:yes
(bootloader) has-slot:dram_train:yes
(bootloader) has-slot:abl:yes
(bootloader) has-slot:bl31:yes
(bootloader) has-slot:tzsw:yes
(bootloader) has-slot:gsa:yes
(bootloader) has-slot:ldfw:yes
(bootloader) has-slot:dpm:yes
(bootloader) has-slot:devinfo:no
(bootloader) has-slot:pinfo:no
(bootloader) has-slot:blenv:no
(bootloader) has-slot:mfg_data:no
(bootloader) has-slot:system:yes
(bootloader) has-slot:system_dlkm:yes
(bootloader) has-slot:system_ext:yes
(bootloader) has-slot:product:yes
(bootloader) has-slot:vendor:yes
(bootloader) has-slot:vendor_dlkm:yes
(bootloader) has-slot:radio:yes
(bootloader) has-slot:bootloader:yes
(bootloader) hw-revision:MP1.0
(bootloader) is-logical:persist:no
(bootloader) is-logical:klog:no
(bootloader) is-logical:misc:no
(bootloader) is-logical:frp:no
(bootloader) is-logical:efs:no
(bootloader) is-logical:efs_backup:no
(bootloader) is-logical:modem_userdata:no
(bootloader) is-logical:metadata:no
(bootloader) is-logical:fips:no
(bootloader) is-logical:boot_a:no
(bootloader) is-logical:init_boot_a:no
(bootloader) is-logical:vendor_boot_a:no
(bootloader) is-logical:vendor_kernel_boot_a:no
(bootloader) is-logical:dtbo_a:no
(bootloader) is-logical:vbmeta_a:no
(bootloader) is-logical:vbmeta_system_a:no
(bootloader) is-logical:vbmeta_vendor_a:no
(bootloader) is-logical:pvmfw_a:no
(bootloader) is-logical:modem_a:no
(bootloader) is-logical:boot_b:no
(bootloader) is-logical:init_boot_b:no
(bootloader) is-logical:vendor_boot_b:no
(bootloader) is-logical:vendor_kernel_boot_b:no
(bootloader) is-logical:dtbo_b:no
(bootloader) is-logical:vbmeta_b:no
(bootloader) is-logical:vbmeta_system_b:no
(bootloader) is-logical:vbmeta_vendor_b:no
(bootloader) is-logical:pvmfw_b:no
(bootloader) is-logical:modem_b:no
(bootloader) is-logical:super:no
(bootloader) is-logical:userdata:no
(bootloader) is-logical:bl1_a:no
(bootloader) is-logical:pbl_a:no
(bootloader) is-logical:bl2_a:no
(bootloader) is-logical:dram_train_a:no
(bootloader) is-logical:abl_a:no
(bootloader) is-logical:bl31_a:no
(bootloader) is-logical:tzsw_a:no
(bootloader) is-logical:gsa_a:no
(bootloader) is-logical:ldfw_a:no
(bootloader) is-logical:dpm_a:no
(bootloader) is-logical:bl1_b:no
(bootloader) is-logical:pbl_b:no
(bootloader) is-logical:bl2_b:no
(bootloader) is-logical:dram_train_b:no
(bootloader) is-logical:abl_b:no
(bootloader) is-logical:bl31_b:no
(bootloader) is-logical:tzsw_b:no
(bootloader) is-logical:gsa_b:no
(bootloader) is-logical:ldfw_b:no
(bootloader) is-logical:dpm_b:no
(bootloader) is-logical:devinfo:no
(bootloader) is-logical:pinfo:no
(bootloader) is-logical:blenv:no
(bootloader) is-logical:mfg_data:no
(bootloader) is-logical:system_a:yes
(bootloader) is-logical:system_b:yes
(bootloader) is-logical:system_dlkm_a:yes
(bootloader) is-logical:system_dlkm_b:yes
(bootloader) is-logical:system_ext_a:yes
(bootloader) is-logical:system_ext_b:yes
(bootloader) is-logical:product_a:yes
(bootloader) is-logical:product_b:yes
(bootloader) is-logical:vendor_a:yes
(bootloader) is-logical:vendor_b:yes
(bootloader) is-logical:vendor_dlkm_a:yes
(bootloader) is-logical:vendor_dlkm_b:yes
(bootloader) is-ramdump-mode:no
(bootloader) is-userspace:no
(bootloader) logical-block-size:0x1000
(bootloader) max-download-size:0xf900000
(bootloader) max-fetch-size:0xf900000
(bootloader) nos-production:yes
(bootloader) off-mode-charge:1
(bootloader) partition-size:persist:0x4000000
(bootloader) partition-size:klog:0x1000000
(bootloader) partition-size:misc:0x100000
(bootloader) partition-size:frp:0x80000
(bootloader) partition-size:efs:0x4000000
(bootloader) partition-size:efs_backup:0x4000000
(bootloader) partition-size:modem_userdata:0x4000000
(bootloader) partition-size:metadata:0x4000000
(bootloader) partition-size:fips:0x200000
(bootloader) partition-size:boot_a:0x4000000
(bootloader) partition-size:init_boot_a:0x800000
(bootloader) partition-size:vendor_boot_a:0x4000000
(bootloader) partition-size:vendor_kernel_boot_a:0x4000000
(bootloader) partition-size:dtbo_a:0x1000000
(bootloader) partition-size:vbmeta_a:0x10000
(bootloader) partition-size:vbmeta_system_a:0x10000
(bootloader) partition-size:vbmeta_vendor_a:0x10000
(bootloader) partition-size:pvmfw_a:0x100000
(bootloader) partition-size:modem_a:0xc800000
(bootloader) partition-size:boot_b:0x4000000
(bootloader) partition-size:init_boot_b:0x800000
(bootloader) partition-size:vendor_boot_b:0x4000000
(bootloader) partition-size:vendor_kernel_boot_b:0x4000000
(bootloader) partition-size:dtbo_b:0x1000000
(bootloader) partition-size:vbmeta_b:0x10000
(bootloader) partition-size:vbmeta_system_b:0x10000
(bootloader) partition-size:vbmeta_vendor_b:0x10000
(bootloader) partition-size:pvmfw_b:0x100000
(bootloader) partition-size:modem_b:0xc800000
(bootloader) partition-size:super:0x1fc800000
(bootloader) partition-size:userdata:0x1b7a615000
(bootloader) partition-size:bl1_a:0x3000
(bootloader) partition-size:pbl_a:0x14000
(bootloader) partition-size:bl2_a:0x87000
(bootloader) partition-size:dram_train_a:0x19000
(bootloader) partition-size:abl_a:0x200000
(bootloader) partition-size:bl31_a:0x40000
(bootloader) partition-size:tzsw_a:0x1400000
(bootloader) partition-size:gsa_a:0x80000
(bootloader) partition-size:ldfw_a:0x400000
(bootloader) partition-size:dpm_a:0x9000
(bootloader) partition-size:bl1_b:0x3000
(bootloader) partition-size:pbl_b:0x14000
(bootloader) partition-size:bl2_b:0x87000
(bootloader) partition-size:dram_train_b:0x19000
(bootloader) partition-size:abl_b:0x200000
(bootloader) partition-size:bl31_b:0x40000
(bootloader) partition-size:tzsw_b:0x1400000
(bootloader) partition-size:gsa_b:0x80000
(bootloader) partition-size:ldfw_b:0x400000
(bootloader) partition-size:dpm_b:0x9000
(bootloader) partition-size:devinfo:0x2000
(bootloader) partition-size:pinfo:0x2000
(bootloader) partition-size:blenv:0x2000
(bootloader) partition-size:mfg_data:0x334000
(bootloader) partition-size:system_a:0x3de1f000
(bootloader) partition-size:system_b:0x6100000
(bootloader) partition-size:system_dlkm_a:0x55000
(bootloader) partition-size:system_dlkm_b:0x0
(bootloader) partition-size:system_ext_a:0x10b9d000
(bootloader) partition-size:system_ext_b:0x0
(bootloader) partition-size:product_a:0xd6d65000
(bootloader) partition-size:product_b:0x0
(bootloader) partition-size:vendor_a:0x2bf9a000
(bootloader) partition-size:vendor_b:0x0
(bootloader) partition-size:vendor_dlkm_a:0x2b24000
(bootloader) partition-size:vendor_dlkm_b:0x0
(bootloader) partition-type:persist:f2fs
(bootloader) partition-type:klog:raw
(bootloader) partition-type:misc:raw
(bootloader) partition-type:frp:raw
(bootloader) partition-type:efs:f2fs
(bootloader) partition-type:efs_backup:f2fs
(bootloader) partition-type:modem_userdata:raw
(bootloader) partition-type:metadata:raw
(bootloader) partition-type:fips:raw
(bootloader) partition-type:boot_a:raw
(bootloader) partition-type:init_boot_a:raw
(bootloader) partition-type:vendor_boot_a:raw
(bootloader) partition-type:vendor_kernel_boot_a:raw
(bootloader) partition-type:dtbo_a:raw
(bootloader) partition-type:vbmeta_a:raw
(bootloader) partition-type:vbmeta_system_a:raw
(bootloader) partition-type:vbmeta_vendor_a:raw
(bootloader) partition-type:pvmfw_a:raw
(bootloader) partition-type:modem_a:raw
(bootloader) partition-type:boot_b:raw
(bootloader) partition-type:init_boot_b:raw
(bootloader) partition-type:vendor_boot_b:raw
(bootloader) partition-type:vendor_kernel_boot_b:raw
(bootloader) partition-type:dtbo_b:raw
(bootloader) partition-type:vbmeta_b:raw
(bootloader) partition-type:vbmeta_system_b:raw
(bootloader) partition-type:vbmeta_vendor_b:raw
(bootloader) partition-type:pvmfw_b:raw
(bootloader) partition-type:modem_b:raw
(bootloader) partition-type:super:raw
(bootloader) partition-type:userdata:raw
(bootloader) partition-type:bl1_a:raw
(bootloader) partition-type:pbl_a:raw
(bootloader) partition-type:bl2_a:raw
(bootloader) partition-type:dram_train_a:raw
(bootloader) partition-type:abl_a:raw
(bootloader) partition-type:bl31_a:raw
(bootloader) partition-type:tzsw_a:raw
(bootloader) partition-type:gsa_a:raw
(bootloader) partition-type:ldfw_a:raw
(bootloader) partition-type:dpm_a:raw
(bootloader) partition-type:bl1_b:raw
(bootloader) partition-type:pbl_b:raw
(bootloader) partition-type:bl2_b:raw
(bootloader) partition-type:dram_train_b:raw
(bootloader) partition-type:abl_b:raw
(bootloader) partition-type:bl31_b:raw
(bootloader) partition-type:tzsw_b:raw
(bootloader) partition-type:gsa_b:raw
(bootloader) partition-type:ldfw_b:raw
(bootloader) partition-type:dpm_b:raw
(bootloader) partition-type:devinfo:raw
(bootloader) partition-type:pinfo:raw
(bootloader) partition-type:blenv:raw
(bootloader) partition-type:mfg_data:raw
(bootloader) partition-type:system_a:raw
(bootloader) partition-type:system_b:raw
(bootloader) partition-type:system_dlkm_a:raw
(bootloader) partition-type:system_dlkm_b:raw
(bootloader) partition-type:system_ext_a:raw
(bootloader) partition-type:system_ext_b:raw
(bootloader) partition-type:product_a:raw
(bootloader) partition-type:product_b:raw
(bootloader) partition-type:vendor_a:raw
(bootloader) partition-type:vendor_b:raw
(bootloader) partition-type:vendor_dlkm_a:raw
(bootloader) partition-type:vendor_dlkm_b:raw
(bootloader) product:cheetah
(bootloader) sbdp:pbl:no
(bootloader) sbdp:bl2:no
(bootloader) sbdp:bl31:no
(bootloader) sbdp:tzsw:no
(bootloader) sbdp:ldfw:no
(bootloader) sbdp:abl:no
(bootloader) sbdp:hv:no
(bootloader) sbdp:gsa:no
(bootloader) sbdp:aoc:no
(bootloader) sbdp:tpu:no
(bootloader) sbdp:ta:no
(bootloader) sbdp:tzprov:no
(bootloader) sbdp:gcf:no
(bootloader) sbdp:pkhash:no
(bootloader) sbdp:ar-check:no
(bootloader) sbdp:ar-update:no
(bootloader) sbdp:allow:no
(bootloader) secure:yes
(bootloader) secure-boot:PRODUCTION
(bootloader) serialno:28191FDH300AZK
(bootloader) slot-count:2
(bootloader) slot-fastboot-ok:a:yes
(bootloader) slot-fastboot-ok:b:yes
(bootloader) slot-retry-count:a:2
(bootloader) slot-retry-count:b:3
(bootloader) slot-successful:a:yes
(bootloader) slot-successful:b:no
(bootloader) slot-suffixes:_a,_b
(bootloader) slot-unbootable:a:no
(bootloader) slot-unbootable:b:no
(bootloader) snapshot-update-status:none
(bootloader) storage-capacity:128 GB
(bootloader) storage-model:MT128GAXAT2U31
(bootloader) storage-power-mode:lanes=2 gear=4 mode=FAST hs_series=SERIES_B
(bootloader) storage-protocol:3.1
(bootloader) storage-rev:0108
(bootloader) storage-serialno:N/A
(bootloader) storage-temperature:30 degrees celsius
(bootloader) storage-ufs-provisioning:Legacy
(bootloader) storage-vendor:MICRON
(bootloader) unlocked:yes
(bootloader) variant:N/A
(bootloader) version:0.4
(bootloader) version-baseband:g5300q-240919-241106-B-12612898
(bootloader) version-bootloader:cloudripper-15.1-12292122
all:
Finished. Total time: 0.336s";

            List<String> partitions = new List<String>();

            partition_selected.Items.Clear();
            string[] lines = (output).Split(new[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string line in lines)
            {
                Console.WriteLine(line);

                if(line.Contains("(Write to device failed (no link))"))
                {
                    if(MessageBox.Show(
                        "Something happened, and I can't communicate with your device!\nPlease reboot your device.",
                        "Fastboot-GUI",
                        MessageBoxButtons.RetryCancel,
                        MessageBoxIcon.Warning
                        ) == DialogResult.Retry)
                    {
                        partition_refresh_Click(sender, e);
                    } else
                    {
                        return;
                    }
                }

                string trimmedLine = line.Trim();
                if (trimmedLine.StartsWith("(bootloader) partition-type:"))
                {
                    string partitionName = trimmedLine.Substring("(bootloader) partition-type:".Length).Trim();
                    partitions.Add(partitionName.Split(':')[0]);
                }
            }

            foreach (string partition in partitions)
            {
                partition_selected.Items.Add(partition);
            }


            MessageBox.Show(
                "Successfully queryed partitions!",
                "Fastboot-GUI",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );

            return;

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "Image Files (*.img)|*.img|All Files (*.*)|*.*";

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                dump_outfile.Text = saveFileDialog1.FileName;
            }
        }

        private void dump_dumpBtn_Click(object sender, EventArgs e)
        {
            ProcessStartInfo fastboot_cmd = new ProcessStartInfo();
            fastboot_cmd.FileName = "fastboot";
            fastboot_cmd.Arguments = "-s " + Device_Selected.SelectedItem + " fetch " + partition_selected.SelectedItem + " " + dump_outfile.Text;
            fastboot_cmd.CreateNoWindow = true;
            fastboot_cmd.RedirectStandardOutput = true;
            fastboot_cmd.UseShellExecute = false;

            Process fastboot_process = new Process();
            fastboot_process.StartInfo = fastboot_cmd;
            fastboot_process.Start();
            
            string output = fastboot_process.StandardOutput.ReadToEnd();
            fastboot_process.WaitForExit();

            if(fastboot_process.ExitCode != 0)
            {
                if (
                    MessageBox.Show(
                        "Dumping " + partition_selected.SelectedItem + " failed.",
                        "Fastboot-GUI",
                        MessageBoxButtons.RetryCancel,
                        MessageBoxIcon.Warning
                        ) == DialogResult.Retry
                    )
                {
                    // weeeee
                    dump_dumpBtn_Click(sender, e);
                }
                else
                {
                    return;
                }
            } else
            {
                MessageBox.Show(
                    "Successfully dumped " + partition_selected.SelectedItem + " to " + dump_outfile.Text + ".",
                    "Fastboot-GUI",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }

        }
    }
}
