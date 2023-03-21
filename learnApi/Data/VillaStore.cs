using learnApi.Models.Dto;

namespace learnApi.Data
{
    public static class VillaStore
    {
        public static List<VillaDTO> villaList = new List<VillaDTO> {
                new VillaDTO { Id = 1, Nmae = "Villa north coast" },
                new VillaDTO { Id = 2, Nmae = "Villa red sea" }
            };
    }
}
