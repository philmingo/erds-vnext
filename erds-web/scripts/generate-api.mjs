import { execSync } from 'node:child_process';
import { writeFileSync, existsSync } from 'node:fs';
import { resolve, dirname } from 'node:path';
import { fileURLToPath } from 'node:url';

const __dirname = dirname(fileURLToPath(import.meta.url));

const API_URL = process.env.API_URL ?? 'https://localhost:5001';
const SPEC_URL = `${API_URL}/openapi/v1.json`;
const OUTPUT = resolve(__dirname, '../src/api/schema.d.ts');

async function fetchSpec() {
  console.log(`Fetching OpenAPI spec from ${SPEC_URL}...`);
  const response = await fetch(SPEC_URL, {
    // Allow self-signed certs in dev
    signal: AbortSignal.timeout(10_000),
  });
  if (!response.ok) {
    throw new Error(`Failed to fetch spec: ${response.status} ${response.statusText}`);
  }
  return await response.text();
}

async function main() {
  const specPath = resolve(__dirname, '../openapi.json');

  try {
    const spec = await fetchSpec();
    writeFileSync(specPath, spec, 'utf-8');
    console.log(`Spec saved to ${specPath}`);
  } catch {
    if (existsSync(specPath)) {
      console.log('API not reachable, using existing openapi.json');
    } else {
      console.error('ERROR: API not reachable and no cached openapi.json found.');
      console.error('Start the API first: dotnet run --project src/ERDS.Api');
      process.exit(1);
    }
  }

  console.log('Generating TypeScript types...');
  execSync(`npx openapi-typescript ${specPath} -o ${OUTPUT}`, {
    stdio: 'inherit',
    cwd: resolve(__dirname, '..'),
  });

  console.log(`Types generated at ${OUTPUT}`);
}

main();
