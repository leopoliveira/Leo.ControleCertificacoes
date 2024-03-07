import type { CertifiedReadType } from "@/types/Certified/CertifiedReadType";

import API from "@/services/Api";

export async function GetByCode(code: string): Promise<CertifiedReadType[]>
{
  try
  {
    const response = await API().get(`/Employee/${ code }/Certifieds`);
    return response.data as CertifiedReadType[];

  } catch (error)
  {
    console.error(error);
    return [] as CertifiedReadType[];
  }
}