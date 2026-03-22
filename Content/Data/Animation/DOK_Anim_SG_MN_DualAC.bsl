@BlockID "DOK_SG_MN_DualAC"
@Version 2
@Author enenra

using Azimuth as Subpart("azimuth")
using Radar as Subpart("radar") parent Azimuth

func moveRadar() {
	if (block.IsWorking() == true) {
		Radar.rotate([0, 1, 0], 360, 180, Linear)
	}
}

action Block() {
	Create() {
		API.StartLoop("moveRadar", 10, -1)
	}
}