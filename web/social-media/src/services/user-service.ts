import axios from "axios";

const API_URL = "http://localhost:5099/api/User";

export interface User {
    id: number;
    nickname: string;
    profileImageUrl: string;
  }

export async function fetchUsers() {
  const { data } = await axios.get<User[]>(API_URL);
  return data;
}
